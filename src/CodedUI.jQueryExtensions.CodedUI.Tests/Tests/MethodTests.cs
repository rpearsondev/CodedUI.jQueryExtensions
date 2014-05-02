using CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Tests
{
    /// <summary>
    ///     Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class MethodTests : AbstractPageTest<MethodTestsPage>
    {
        [TestMethod]
        public void GetsHtmlFromDiv()
        {
            Assert.IsTrue(TestedPage.GetHtmlFromDiv() == "<a></a>");
        }

        [TestMethod]
        public void GetsTextFromAnchor()
        {
            Assert.IsTrue(TestedPage.GetTextFromAnchor() == "text in anchor");
        }

        [TestMethod]
        public void GetsValueFromInput()
        {
            Assert.IsTrue(TestedPage.GetValueFromInput() == "value in input");
        }
    }
}