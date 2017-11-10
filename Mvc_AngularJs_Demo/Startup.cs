using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc_AngularJs_Demo.Startup))]
namespace Mvc_AngularJs_Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
