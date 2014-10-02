using CodedUI.jQueryExtensions;
using CodedUI.jQueryExtensions.Test.Core;
using Microsoft.Services.TestTools.UITesting.Html;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages
{
    [EntryUri(Constants.MethodsPage)]
    public class MethodTestsPage: Page
    {
        public string GetTextFromAnchor()
        {
            return Browser.JQueryText("#anchorWithText");
        }

        public string GetHtmlFromDiv()
        {
            return Browser.JQueryHtml("#divWithHtml");
        }

        public string GetValueFromInput()
        {
            return Browser.JQueryVal("#inputWithValue");
        }
    }
}