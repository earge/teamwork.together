using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EARGE.Team.Startup))]
namespace EARGE.Team
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
