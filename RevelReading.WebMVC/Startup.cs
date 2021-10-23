using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RevelReading.WebMVC.Startup))]
namespace RevelReading.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
