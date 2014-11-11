using CodedUI.jQueryExtensions.Test.Core;
using CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages;
using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Tests
{
    [CodedUITest]
    public class MethodTests : AbstractPageTest
    {
        MethodTestsPage _testedPage;

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
        public void GetsHtmlFromDivIE()
        {
            GetsHtmlFromDiv(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void GetsHtmlFromDivChrome()
        {
            GetsHtmlFromDiv(Constants.Browsers.Chrome);
            KillChromeDriver();
        }

        //[TestMethod]
        //[TestCategory(Constants.Browsers.FireFox)]
        //public void GetsHtmlFromDivFireFox()
        //{
        //    GetsHtmlFromDiv(Constants.Browsers.FireFox);
        //}

        private void GetsHtmlFromDiv(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<MethodTestsPage>();
            Assert.IsTrue(_testedPage.GetHtmlFromDiv() == "<a></a>");
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.IE)]
        public void GetsTextFromAnchorIE()
        {
            GetsTextFromAnchor(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void GetsTextFromAnchorChrome()
        {
            GetsTextFromAnchor(Constants.Browsers.Chrome);
            KillChromeDriver();
        }

        //[TestMethod]
        //[TestCategory(Constants.Browsers.FireFox)]
        //public void GetsTextFromAnchorFireFox()
        //{
        //    GetsTextFromAnchor(Constants.Browsers.FireFox);
        //}

        private void GetsTextFromAnchor(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<MethodTestsPage>();
            Assert.IsTrue(_testedPage.GetTextFromAnchor() == "text in anchor");
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.IE)]
        public void GetsValueFromInputIE()
        {
            GetsTextFromAnchor(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void GetsValueFromInputChrome()
        {
            GetsTextFromAnchor(Constants.Browsers.Chrome);
            KillChromeDriver();
        }

        //[TestMethod]
        //[TestCategory(Constants.Browsers.FireFox)]
        //public void GetsValueFromInputFireFox()
        //{
        //    GetsTextFromAnchor(Constants.Browsers.FireFox);
        //}

        private void GetsValueFromInput(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<MethodTestsPage>();
            Assert.IsTrue(_testedPage.GetValueFromInput() == "value in input");
        }
    }
}