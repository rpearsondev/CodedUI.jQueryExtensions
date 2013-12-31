using Owin;

namespace CodedUI.jQueryExtensions.WebsiteHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}