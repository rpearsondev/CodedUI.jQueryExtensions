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
    public class JQueryExistsTests : AbstractPageTest
    {
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
        public void DoesNotRemoveJquery()
        {
            BrowserWindow.CurrentBrowser = "Firefox";
            var testedPage = Page.Launch<ExistsInjectPage>();
            Assert.IsTrue(testedPage.DoesJqueryExist());
            Assert.IsTrue(testedPage.WaitForBody());
            Assert.IsTrue(testedPage.DoesJqueryExist());
        }
    }
}