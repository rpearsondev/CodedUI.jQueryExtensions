using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Hosting.Self;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests
{
    [DeploymentItem(@"../views")]
    public abstract class AbstractPageTest
    {
        private static Process _hostedWebsite;
        private static NancyHost _server = null;
        private static Object _LockingObject = new Object();

        public static void StartWebserver(TestContext context)
        {
            lock (_LockingObject)
            {
                if (_server != null)
                {
                    return;
                }
                _server = new NancyHost(new Uri("http://localhost:8080"));
                _server.Start();
            }
            BrowserWindow.CurrentBrowser = "Chrome";
        }

        public static void StopWebserver()
        {
            _server.Stop();
        }
    }
}