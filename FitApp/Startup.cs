using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitApp.Startup))]
namespace FitApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
