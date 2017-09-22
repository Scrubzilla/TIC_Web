using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TIC_Web.Startup))]
namespace TIC_Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
