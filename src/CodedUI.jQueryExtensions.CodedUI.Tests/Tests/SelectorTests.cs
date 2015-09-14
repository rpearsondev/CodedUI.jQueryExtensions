﻿using System;
using System.Linq;
using CodedUI.jQueryExtensions.Test.Core;
using CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages;
using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Tests
{
    [CodedUITest]
    public class SelectorTests : AbstractPageTest
    {
        SelectorTestsPage _testedPage;

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
        [TestCategory(Constants.Browsers.IE)]
        public void SelectsMultipleElementsIE()
        {
            SelectsMultipleElements(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void SelectsMultipleElementsChrome()
        {
            SelectsMultipleElements(Constants.Browsers.Chrome);
            KillChromeDriver();
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.FireFox)]
        public void SelectsMultipleElementsFireFox()
        {
            SelectsMultipleElements(Constants.Browsers.FireFox);
        }

        private void SelectsMultipleElements(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<SelectorTestsPage>();

            HtmlControl[] liElements = _testedPage.GetLiElements().ToArray();
            Assert.AreEqual(liElements[0].InnerText, "1");
            Assert.AreEqual(liElements[1].InnerText, "2");
            Assert.AreEqual(liElements[2].InnerText, "3");
        }

        
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        [TestCategory(Constants.Browsers.IE)]
        public void SelectMultipleElementsAsWrongTypeIE()
        {
            SelectMultipleElementsAsWrongType(Constants.Browsers.IE);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        [TestCategory(Constants.Browsers.Chrome)]
        public void SelectMultipleElementsAsWrongTypeChrome()
        {
            SelectMultipleElementsAsWrongType(Constants.Browsers.Chrome);
            KillChromeDriver();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        [TestCategory(Constants.Browsers.FireFox)]
        public void SelectMultipleElementsAsWrongTypeFireFox()
        {
            SelectMultipleElementsAsWrongType(Constants.Browsers.FireFox);
        }

        private void SelectMultipleElementsAsWrongType(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<SelectorTestsPage>();
            var res = _testedPage.DoInvalidCastGetLiElements();
        }


        [TestMethod]
        [TestCategory(Constants.Browsers.IE)]
        public void FindAnchorThatContainsIE()
        {
            FindAnchorThatContains(Constants.Browsers.IE);
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.Chrome)]
        public void FindAnchorThatContainsChrome()
        {
            FindAnchorThatContains(Constants.Browsers.Chrome);
            KillChromeDriver();
        }

        [TestMethod]
        [TestCategory(Constants.Browsers.FireFox)]
        public void FindAnchorThatContainsFireFox()
        {
            FindAnchorThatContains(Constants.Browsers.FireFox);
        }

        private void FindAnchorThatContains(string browser)
        {
            BrowserWindow.CurrentBrowser = browser;
            _testedPage = Page.Launch<SelectorTestsPage>();

            var liElements = _testedPage.GetAnchorThatContainsExplore();
            Assert.AreEqual(liElements.First().InnerText, "Explore");
            
        }

    }
}