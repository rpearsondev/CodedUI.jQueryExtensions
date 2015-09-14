﻿using CodedUI.jQueryExtensions.Test.Core;
using CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages;
using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Tests
{
    [CodedUITest]
    public class ExistsTests : AbstractPageTest
    {
        ExistsTestsPage _testedPage;

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
        public void PresentDivExistsIE()
        {
            PresentDivExists(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void PresentDivExistsChrome()
        {
            PresentDivExists(Constants.Browsers.Chrome);
            KillChromeDriver();
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.IE)]
        public void NotPresentDivNotExistsIE()
        {
            NonPresentDivDoesNotExists(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void NotPresentDivNotExistsChrome()
        {
            NonPresentDivDoesNotExists(Constants.Browsers.Chrome);
            KillChromeDriver();
        }

        public void NonPresentDivDoesNotExists(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<ExistsTestsPage>();
            Assert.IsFalse(_testedPage.NonExistentDivExists());
        }


        private void PresentDivExists(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<ExistsTestsPage>();
            Assert.IsTrue(_testedPage.DivExists());

        }
    }
}