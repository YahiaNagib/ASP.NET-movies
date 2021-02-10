using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheApp.Startup))]
namespace TheApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
