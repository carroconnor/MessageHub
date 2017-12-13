using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MessageHub.Startup))]
namespace MessageHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
