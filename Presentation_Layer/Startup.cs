using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Presentation_Layer.Startup))]
namespace Presentation_Layer
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
