using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteControlDetenido.Startup))]
namespace SiteControlDetenido
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}