using CodedUI.jQueryExtensions;
using CodedUI.jQueryExtensions.Test.Core;
using Microsoft.Services.TestTools.UITesting.Html;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests.Pages
{
    [EntryUri(Constants.WaitForExistsTestPath)]
    public class WaitForTestsPage : Page
    {
        public bool WaitForDivDefaultTimeout()
        {
            return Browser.JQueryWaitForExists("#divExistAfter5SecondsTest");
        }

        public bool WaitForDivOverloadedTimeout()
        {
            return Browser.JQueryWaitForExists("#divExistAfter5SecondsTest", 2*1000);
        }

    }
}