using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RocketLeagueCarBuilds.Startup))]
namespace RocketLeagueCarBuilds
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
