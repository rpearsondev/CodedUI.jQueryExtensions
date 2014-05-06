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

        [TestInitialize]
        public void TestInitialize()
        {
            BrowserWindow.CurrentBrowser = "Firefox";
            _testedPage = Page.Launch<MethodTestsPage>();
        }

        [TestMethod]
        public void GetsHtmlFromDiv()
        {
            
            Assert.IsTrue(_testedPage.GetHtmlFromDiv() == "<a></a>");
        }

        [TestMethod]
        public void GetsTextFromAnchor()
        {
            Assert.IsTrue(_testedPage.GetTextFromAnchor() == "text in anchor");
        }

        [TestMethod]
        public void GetsValueFromInput()
        {
            Assert.IsTrue(_testedPage.GetValueFromInput() == "value in input");
        }
    }
}