using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HashPass.Web.Startup))]
namespace HashPass.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
