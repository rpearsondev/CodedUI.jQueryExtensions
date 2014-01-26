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
    public class WaitForExistsTests : AbstractPageTest<WaitForExistsTestsPage>
    {

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            StartWebserver(context);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            StopWebserver();
        }


        [TestMethod]
        public void WaitForExistsWithDefaultTimeout()
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