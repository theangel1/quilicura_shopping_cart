using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quilicura.Startup))]
namespace Quilicura
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
