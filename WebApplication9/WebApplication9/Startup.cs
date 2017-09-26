using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication9.Startup))]
namespace WebApplication9
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
