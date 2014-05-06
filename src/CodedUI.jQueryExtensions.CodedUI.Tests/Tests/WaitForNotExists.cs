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

        [TestInitialize]
        public void TestInitialize()
        {
            BrowserWindow.CurrentBrowser = "Chrome";
            _testedPage = Page.Launch<WaitForNotExistsTestsPage>();
        }

        [TestMethod]
        public void WaitForNotExistsWithDefaultTimeout()
        {
            Assert.IsTrue(_testedPage.WaitForDivDefaultTimeout());
        }

        [TestMethod]
        public void WaitForExistsOnlyWaitsForSpecifiedTimeout()
        {
            Assert.IsFalse(_testedPage.WaitForDivOverloadedTimeout());
        }

    }
}