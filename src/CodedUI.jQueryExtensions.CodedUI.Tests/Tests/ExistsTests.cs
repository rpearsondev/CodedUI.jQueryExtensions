using CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Tests
{
    /// <summary>
    ///     Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class ExistsTests : AbstractPageTest<ExistsTestsPage>
    {
        [TestMethod]
        public void PresentDivExists()
        {
            Assert.IsTrue(TestedPage.DivExists());
        }

        [TestMethod]
        public void NonPresentDivDoesNotExists()
        {
            Assert.IsFalse(TestedPage.NonExistentDivExists());
        }
    }
}