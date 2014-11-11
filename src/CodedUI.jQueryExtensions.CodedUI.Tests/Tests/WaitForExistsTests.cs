using CodedUI.jQueryExtensions.Test.Core;
using CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages;
using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Tests
{
    [CodedUITest]
    public class WaitForExistsTests : AbstractPageTest
    {
        private WaitForExistsTestsPage _testedPage;

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
        public void WaitForExistsWithDefaultTimeoutIE()
        {
            WaitForExistsWithDefaultTimeout(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void WaitForExistsWithDefaultTimeoutChrome()
        {
            WaitForExistsWithDefaultTimeout(Constants.Browsers.Chrome);
            KillChromeDriver();
        }

        //[TestMethod]
        //[TestCategory(Constants.Browsers.FireFox)]
        //public void WaitForExistsWithDefaultTimeoutFireFox()
        //{
        //    WaitForExistsWithDefaultTimeout(Constants.Browsers.FireFox);
        //}

        private void WaitForExistsWithDefaultTimeout(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<WaitForExistsTestsPage>();
            Assert.IsTrue(_testedPage.WaitForDivDefaultTimeout());
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.IE)]
        public void WaitForExistsOnlyWaitsForSpecifiedTimeoutIE()
        {
            WaitForExistsOnlyWaitsForSpecifiedTimeout(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void WaitForExistsOnlyWaitsForSpecifiedTimeoutChrome()
        {
            WaitForExistsOnlyWaitsForSpecifiedTimeout(Constants.Browsers.Chrome);
            KillChromeDriver();
        }

        //[TestMethod]
        //[TestCategory(Constants.Browsers.FireFox)]
        //public void WaitForExistsOnlyWaitsForSpecifiedTimeoutFireFox()
        //{
        //    WaitForExistsOnlyWaitsForSpecifiedTimeout(Constants.Browsers.FireFox);
        //}

        private void WaitForExistsOnlyWaitsForSpecifiedTimeout(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<WaitForExistsTestsPage>();
            Assert.IsFalse(_testedPage.WaitForDivOverloadedTimeout());
        }
    }
}