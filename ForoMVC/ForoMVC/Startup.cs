using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForoMVC.Startup))]
namespace ForoMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
