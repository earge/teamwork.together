using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EARGE.TeamAdmin.Startup))]
namespace EARGE.TeamAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
