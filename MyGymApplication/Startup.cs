using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyGymApplication.Startup))]
namespace MyGymApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
