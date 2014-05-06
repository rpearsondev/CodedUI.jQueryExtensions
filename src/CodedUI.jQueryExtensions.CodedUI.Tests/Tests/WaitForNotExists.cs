using CodedUI.jQueryExtensions.Test.Core;
using CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages;
using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Tests
{
    /// <summary>
    ///     Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class WaitForNotExistsTests : AbstractPageTest
    {
        private WaitForNotExistsTestsPage _testedPage;

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
        public void WaitForNotExistsWithDefaultTimeoutIE()
        {
            WaitForNotExistsWithDefaultTimeout(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void WaitForNotExistsWithDefaultTimeoutChrome()
        {
            WaitForNotExistsWithDefaultTimeout(Constants.Browsers.Chrome);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.FireFox)]
        public void WaitForNotExistsWithDefaultTimeoutFireFox()
        {
            WaitForNotExistsWithDefaultTimeout(Constants.Browsers.FireFox);
        }

        private void WaitForNotExistsWithDefaultTimeout(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<WaitForNotExistsTestsPage>();
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
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.FireFox)]
        public void WaitForExistsOnlyWaitsForSpecifiedTimeoutFireFox()
        {
            WaitForExistsOnlyWaitsForSpecifiedTimeout(Constants.Browsers.FireFox);
        }

        [TestMethod]
        private void WaitForExistsOnlyWaitsForSpecifiedTimeout(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<WaitForNotExistsTestsPage>();
            Assert.IsFalse(_testedPage.WaitForDivOverloadedTimeout());
        }

    }
}