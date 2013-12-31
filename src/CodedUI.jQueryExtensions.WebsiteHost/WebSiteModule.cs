using CodedUI.jQueryExtensions.Test.Core;
using Nancy;

namespace CodedUI.jQueryExtensions.WebSite
{
    public class WebsiteModule : NancyModule
    {
        public WebsiteModule()
        {
            Get["/"] = _ => { return View["viewWebsiteRoot", new {}]; };

            Get[Constants.SelectorTestPath] = _ => { return View["viewSelectorTests", new {}]; };

            Get[Constants.ExistTestPath] = _ => { return View["viewExistsTests", new {}]; };

            Get[Constants.WaitForExistsTestPath] = _ => { return View["viewWaitForExistsTests", new {}]; };
        }
    }
}