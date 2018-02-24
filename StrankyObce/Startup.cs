using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StrankyObce.Startup))]
namespace StrankyObce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
