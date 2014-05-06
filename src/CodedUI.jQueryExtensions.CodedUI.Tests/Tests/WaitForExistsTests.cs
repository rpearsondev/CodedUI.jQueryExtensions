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

        [TestInitialize]
        public void TestInitialize()
        {
            BrowserWindow.CurrentBrowser = "Firefox";
            _testedPage = Page.Launch<WaitForExistsTestsPage>();
        }

        [TestMethod]
        public void WaitForExistsWithDefaultTimeout()
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