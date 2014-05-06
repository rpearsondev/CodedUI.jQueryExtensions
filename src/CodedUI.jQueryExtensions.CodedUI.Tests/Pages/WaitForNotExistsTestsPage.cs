using CodedUI.jQueryExtensions;
using CodedUI.jQueryExtensions.Test.Core;
using Microsoft.Services.TestTools.UITesting.Html;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages
{
    [EntryUri(Constants.Pages.WaitForNotExistsTests)]
    public class WaitForNotExistsTestsPage : Page
    {
        public bool WaitForDivDefaultTimeout()
        {
            return Browser.JQueryWaitForNotExists("#divDisappearAfter5SecondsTest");
        }

        public bool WaitForDivOverloadedTimeout()
        {
            return Browser.JQueryWaitForNotExists("#divDisappearAfter5SecondsTest", 2 * 1000);
        }

    }
}