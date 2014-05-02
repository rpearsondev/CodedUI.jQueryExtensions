using System;
using System.Collections.Generic;
using System.Linq;
using CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Tests
{
    /// <summary>
    ///     Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class SelectorTests : AbstractPageTest<SelectorTestsPage>
    {
        [TestMethod]
        public void SelectsMultipleElements()
        {
            HtmlControl[] liElements = TestedPage.GetLiElements().ToArray();
            Assert.AreEqual(liElements[0].InnerText, "1");
            Assert.AreEqual(liElements[1].InnerText, "2");
            Assert.AreEqual(liElements[2].InnerText, "3");
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidCastException))]
        public void SelectMultipleElementsAsWrongType()
        {
            IEnumerable<HtmlButton> res = TestedPage.DoInvalidCastGetLiElements();
        }
    }
}