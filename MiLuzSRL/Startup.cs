using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiLuzSRL.Startup))]
namespace MiLuzSRL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
