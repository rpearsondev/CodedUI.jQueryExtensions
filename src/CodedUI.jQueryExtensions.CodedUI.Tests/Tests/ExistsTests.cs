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
        public void PresentDivExistsIE()
        {
            BrowserWindow.CurrentBrowser = Constants.Browsers.IE;
            _testedPage = Page.Launch<ExistsTestsPage>();
            Assert.IsTrue(_testedPage.DivExists());

        }

        [TestMethod]
        public void NonPresentDivDoesNotExists()
        {
            BrowserWindow.CurrentBrowser = Constants.Browsers.IE;
            _testedPage = Page.Launch<ExistsTestsPage>();
            Assert.IsFalse(_testedPage.NonExistentDivExists());
        }
    }
}