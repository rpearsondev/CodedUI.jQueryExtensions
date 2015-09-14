﻿using CodedUI.jQueryExtensions.Test.Core;
using CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages;
using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Tests
{
    [CodedUITest]
    public class JQueryNotExistsTests : AbstractPageTest
    {
        [ClassInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            StartWebserver(context);
        }

        [ClassCleanup]
        public static void AssemblyCleanup()
        {
            StopWebserver();
        }


        [TestMethod]
        [TestCategory(Constants.Browsers.IE)]
        public void DoesNotRemoveJqueryIE()
        {
            DoesNotRemoveJquery(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void DoesNotRemoveJqueryChrome()
        {
            DoesNotRemoveJquery(Constants.Browsers.Chrome);
            KillChromeDriver();
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.FireFox)]
        public void DoesNotRemoveJqueryFireFox()
        {
            DoesNotRemoveJquery(Constants.Browsers.FireFox);
        }


        private void DoesNotRemoveJquery(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            var testedPage = Page.Launch<NotExistsInjectPage>();
            Assert.IsTrue(testedPage.DoesJqueryExist().Equals(false));
            Assert.IsTrue(testedPage.WaitForBody());
            Assert.IsTrue(testedPage.DoesJqueryExist().Equals(false));
        }

    }
}