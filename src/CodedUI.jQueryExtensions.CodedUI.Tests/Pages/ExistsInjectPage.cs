using CodedUI.jQueryExtensions;
using CodedUI.jQueryExtensions.Test.Core;
using Microsoft.Services.TestTools.UITesting.Html;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages
{
    [EntryUri(Constants.ExistsInjectTests)]
    public class ExistsInjectPage : Page
    {
        public bool DoesJqueryExist()
        {
            return (bool) Browser.ExecuteScript("return (typeof $ == 'function')");
        }

        public bool WaitForBody()
        {
            return Browser.JQueryWaitForExists("body");
        }

     
    }
}