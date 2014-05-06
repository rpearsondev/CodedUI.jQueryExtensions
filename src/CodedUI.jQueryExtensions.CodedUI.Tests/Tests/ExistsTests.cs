using CodedUI.jQueryExtensions.CodedUI.Tests.Pages;
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


        [TestInitialize]
        public void TestInitialize()
        {
            BrowserWindow.CurrentBrowser = "Firefox";
            _testedPage = Page.Launch<ExistsTestsPage>();
        }

        [TestMethod]
        public void PresentDivExists()
        {
            Assert.IsTrue(_testedPage.DivExists());
        }

        [TestMethod]
        public void NonPresentDivDoesNotExists()
        {
            Assert.IsFalse(_testedPage.NonExistentDivExists());
        }
    }
}