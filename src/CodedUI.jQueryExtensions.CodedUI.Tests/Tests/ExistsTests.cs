using CodedUI.jQueryExtensions.CodedUI.Tests.Pages;
using CodedUI.jQueryExtensions.Test.Core;
using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Tests
{
    /// <summary>
    ///     Summary description for CodedUITest1
    /// </summary>
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
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.FireFox)]
        public void PresentDivExistsFireFox()
        {
            PresentDivExists(Constants.Browsers.FireFox);
        }

        private void PresentDivExists(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<ExistsTestsPage>();
            Assert.IsTrue(_testedPage.DivExists());
        }


        [TestMethod]
        [TestCategory(Constants.Browsers.IE)]
        public void NonPresentDivDoesNotExistsIE()
        {
            NonPresentDivDoesNotExists(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void NonPresentDivDoesNotExistsChrome()
        {
            NonPresentDivDoesNotExists(Constants.Browsers.Chrome);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.FireFox)]
        public void NonPresentDivDoesNotExistsFireFox()
        {
            NonPresentDivDoesNotExists(Constants.Browsers.FireFox);
        }


        private void NonPresentDivDoesNotExists(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<ExistsTestsPage>();
            Assert.IsFalse(_testedPage.NonExistentDivExists());
        }
    }
}