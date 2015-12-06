using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Promistr.Startup))]
namespace Promistr
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
