using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Muzzo.Startup))]
namespace Muzzo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
