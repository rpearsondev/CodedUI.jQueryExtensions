using CodedUI.jQueryExtensions.Test.Core;
using Nancy;

namespace CodedUIjQuery.jQueryExtensions.CodedUI.Tests
{
    public class WebsiteModule : NancyModule
    {
        public WebsiteModule()
        {
            Get["/"] = _ => { return View["viewWebsiteRoot", new {}]; };

            Get[Constants.Pages.SelectorTestPath] = _ => { return View["viewSelectorTests", new {}]; };

            Get[Constants.Pages.ExistTestPath] = _ => { return View["viewExistsTests", new { }]; };

            Get[Constants.Pages.WaitForExistsTestPath] = _ => { return View["viewWaitForExistsTests", new { }]; };

            Get[Constants.Pages.ExistsInjectTests] = _ => { return View["viewJQueryExistsInjectTests", new { }]; };

            Get[Constants.Pages.NotExistsInjectTests] = _ => { return View["viewJQueryNotExistsInjectTests", new { }]; };

            Get[Constants.Pages.WaitForNotExistsTests] = _ => { return View["viewWaitForNotExistsTests", new { }]; };

            Get[Constants.Pages.MethodsPage] = _ => { return View["viewMethodsTests", new { }]; };
        }
    }
}