using System.Diagnostics;
using System.IO;
using System.Reflection;
using CodedUI.jQueryExtensions.CodedUI.Tests.Pages;
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
    public class JQueryExistsTests : AbstractPageTest<JQueryExistsInjectPage>
    {
      
        [TestMethod]
        public void DoesNotRemoveJquery()
        {
            Assert.IsTrue(TestedPage.DoesJqueryExist());
            Assert.IsTrue(TestedPage.WaitForBody());
            Assert.IsTrue(TestedPage.DoesJqueryExist());
        }

    }
}