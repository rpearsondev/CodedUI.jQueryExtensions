using System.Collections.Generic;
using CodedUI.jQueryExtensions.Test.Core;
using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CodedUI.jQueryExtensions.CodedUI.Tests.Pages
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
    }
}