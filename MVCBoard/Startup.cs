using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBoard.Startup))]
namespace MVCBoard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
