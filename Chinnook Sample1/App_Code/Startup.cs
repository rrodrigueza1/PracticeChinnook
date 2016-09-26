using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chinnook_Sample.Startup))]
namespace Chinnook_Sample
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
