using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SICS___WEB_2._0.Startup))]
namespace SICS___WEB_2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
