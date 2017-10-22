using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_4fitter.Startup))]
namespace _4fitter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
