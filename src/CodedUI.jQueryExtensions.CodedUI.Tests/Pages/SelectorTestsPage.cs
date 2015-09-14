﻿using System.Collections.Generic;
using System.Windows.Forms;
using CodedUI.jQueryExtensions;
using CodedUI.jQueryExtensions.Test.Core;
using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages
{
    [EntryUri(Constants.Pages.SelectorTestPath)]
    public class SelectorTestsPage : Page
    {
        public IEnumerable<HtmlControl> GetLiElements()
        {
            return Browser.JQuerySelect<HtmlControl>("#multipleElementsTest li");
        }

        public IEnumerable<HtmlButton> DoInvalidCastGetLiElements()
        {
            return Browser.JQuerySelect<HtmlButton>("#multipleElementsTest li");
        }

        public IEnumerable<HtmlHyperlink> GetAnchorThatContainsExplore()
        {
            return Browser.JQuerySelect<HtmlHyperlink>("a:contains(\"Explore\")");
        }
    }
}