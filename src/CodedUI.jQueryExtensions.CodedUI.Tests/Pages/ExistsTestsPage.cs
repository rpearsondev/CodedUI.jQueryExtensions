using CodedUI.jQueryExtensions.Test.Core;
using Microsoft.Services.TestTools.UITesting.Html;

namespace CodedUI.jQueryExtensions.CodedUI.Tests.Pages
{
    [EntryUri(Constants.Pages.ExistTestPath)]
    public class ExistsTestsPage : Page
    {
        public bool DivExists()
        {
            return Browser.JQueryExists("#divExistTrueTest");
        }

        public bool NonExistentDivExists()
        {
            return Browser.JQueryExists("#divExistFalseTest");
        }
    }
}