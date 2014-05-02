using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UITesting;


namespace CodedUI.jQueryExtensions
{
    public static class JQueryExtensions
    {
        public const int WaitForTimeout = 10000;
        public const int WaitForIterationTimeout = 500;
        public const string JQuerySrcConfigurationKeyName = "CodedUI.JQueryExtensions.jQuerySrc";
        public const string DefaultJquerySrc = "//code.jquery.com/jquery-latest.min.js";

        /// <summary>
        /// Runs a jQuery selector and returns the result
        /// </summary>
        /// <example>  
        /// Returning a list of HtmlControls using the <see cref="JQuerySelect"/> method.
        /// <code> 
        /// public IEnumerable&lt;HtmlControl&gt; GetLiElements()
        /// {
        ///     return Browser.JQuerySelect&lt;HtmlControl&gt;("#multipleElementsTest li");
        /// }
        /// </code> 
        /// </example>
        /// <typeparam name="T">The type of object the result should be cast to.</typeparam>
        /// <param name="window"></param>
        /// <param name="selector">The jQuery selector.</param>
        /// <returns>An enumerable of the specified type.</returns>
        public static IEnumerable<T> JQuerySelect<T>(this BrowserWindow window, string selector)
        {
            EnsureJqueryInPage(window);

            var controlsBySelector =
                (List<object>) window.ExecuteScript(string.Format("return CodedUI.jQueryExtensions.jQuery('{0}')", selector));

            if (controlsBySelector.Any(x => !(x is T)))
            {
                throw new InvalidCastException(
                    string.Format("One or more object(s) returned by the jQuery selector could not be cast to {0}",
                        typeof (T).Name));
            }

            return controlsBySelector.Select(x => (T) x);
        }

        /// <summary>
        /// Returns the combined text contents of each element in the set of matched elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="window"></param>
        /// <param name="selector">The jQuery selector.</param>
        /// <returns></returns>
        public static string JQueryText(this BrowserWindow window, string selector)
        {
            EnsureJqueryInPage(window);

            var res = window.ExecuteScript(string.Format("return CodedUI.jQueryExtensions.jQuery('{0}').text()", selector));

            return res == null ? null : res.ToString();
        }

        /// <summary>
        /// Returns the HTML contents of the first element in the set of matched elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="window"></param>
        /// <param name="selector">The jQuery selector.</param>
        /// <returns></returns>
        public static string JQueryHtml(this BrowserWindow window, string selector)
        {
            EnsureJqueryInPage(window);

            var res = window.ExecuteScript(string.Format("return CodedUI.jQueryExtensions.jQuery('{0}').html()", selector));

            return res == null ? null : res.ToString();
        }

        /// <summary>
        /// Returns the current value of the first element in the set of matched elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="window"></param>
        /// <param name="selector">The jQuery selector.</param>
        /// <returns></returns>
        public static string JQueryVal(this BrowserWindow window, string selector)
        {
            EnsureJqueryInPage(window);

            var res = window.ExecuteScript(string.Format("return CodedUI.jQueryExtensions.jQuery('{0}').val()", selector));

            return res == null ? null : res.ToString();
        }

        /// <summary>
        /// Return true if selector returns any elements
        /// </summary>
        /// <example>
        /// Returns true if there is an element on the page that has the id of 'divExistTrueTest'
        /// <code>
        /// Browser.JQueryExists("#divExistTrueTest");
        /// </code>
        /// </example>
        /// <param name="window"></param>
        /// <param name="selector">The jQuery selector.</param>
        /// <returns></returns>
        public static bool JQueryExists(this BrowserWindow window, string selector)
        {
            return JQuerySelect<object>(window, selector).Any();
        }

        /// <summary>
        /// Waits 10 Seconds for an element to exist. If no element exists after 10 seconds it will return false.
        /// </summary>
        /// <remarks>
        /// Will block until element exists or timeout reached.
        /// </remarks>
        /// <param name="window"></param>
        /// <param name="selector">The jQuery selector.</param>
        /// <returns></returns>
        public static bool JQueryWaitForExists(this BrowserWindow window, string selector)
        {
            return JQueryWaitForExists(window, selector, WaitForTimeout);
        }

        /// <summary>
        /// Waits N milliseconds for an element to exist. If no element exists after N milliseconds it will return false.
        /// </summary>
        /// <remarks>
        /// Will block until element exists or timeout reached.
        /// </remarks>
        /// <param name="window"></param>
        /// <param name="selector">The jQuery selector.</param>
        /// <param name="timeoutMilliSeconds">The timeout in milliseconds to wait.</param>
        /// <returns></returns>
        public static bool JQueryWaitForExists(this BrowserWindow window, string selector, int timeoutMilliSeconds)
        {
            DateTime startDateTime = DateTime.UtcNow;

            do
            {
                if (JQueryExists(window, selector))
                {
                    return true;
                }
                Thread.Sleep(WaitForIterationTimeout);
            } while ((DateTime.UtcNow - startDateTime).TotalMilliseconds < timeoutMilliSeconds);

            return false;
        }


        /// <summary>
        /// Waits 10 Seconds for an element to not exist. If element still exists after 10 seconds it will return false.
        /// </summary>
        /// <remarks>
        /// Will block until element exists or timeout reached.
        /// </remarks>
        /// <param name="window"></param>
        /// <param name="selector">The jQuery selector.</param>
        /// <returns></returns>
        public static bool JQueryWaitForNotExists(this BrowserWindow window, string selector)
        {
            return JQueryWaitForNotExists(window, selector, WaitForTimeout);
        }

        /// <summary>
        /// Waits N milliseconds for an element to not exist. If element still exists after N milliseconds it will return false.
        /// </summary>
        /// <remarks>
        /// Will block until doesn't element exists or timeout reached.
        /// </remarks>
        /// <param name="window"></param>
        /// <param name="selector">The jQuery selector.</param>
        /// <param name="timeoutMilliSeconds">The timeout in milliseconds to wait.</param>
        /// <returns></returns>
        public static bool JQueryWaitForNotExists(this BrowserWindow window, string selector, int timeoutMilliSeconds)
        {
            DateTime startDateTime = DateTime.UtcNow;

            do
            {
                if (!JQueryExists(window, selector))
                {
                    return true;
                }
                Thread.Sleep(WaitForIterationTimeout);
            } while ((DateTime.UtcNow - startDateTime).TotalMilliseconds < timeoutMilliSeconds);

            return false;
        }


        private static void EnsureJqueryInPage(BrowserWindow window)
        {
            string loadJqueryJs = JavaScript.loadjQuery;
            string jquerySrc = DefaultJquerySrc;

            if (ConfigurationManager.AppSettings.AllKeys.Contains(JQuerySrcConfigurationKeyName))
            {
                jquerySrc = ConfigurationManager.AppSettings[JQuerySrcConfigurationKeyName];
            }

            var stringBuilder = new StringBuilder(loadJqueryJs);
            stringBuilder.Replace("$jquerySrc$", jquerySrc);

            window.ExecuteScript(stringBuilder.ToString());
        }
    }
}
