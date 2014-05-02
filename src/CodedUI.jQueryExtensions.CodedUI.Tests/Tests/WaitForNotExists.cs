using CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Tests
{
    /// <summary>
    ///     Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class WaitForNotExistsTests : AbstractPageTest<WaitForNotExistsTestsPage>
    {
        [TestMethod]
        public void WaitForNotExistsWithDefaultTimeout()
        {
            Assert.IsTrue(TestedPage.WaitForDivDefaultTimeout());
        }

        [TestMethod]
        public void WaitForExistsOnlyWaitsForSpecifiedTimeout()
        {
            Assert.IsFalse(TestedPage.WaitForDivOverloadedTimeout());
        }
    }
}