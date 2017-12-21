using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DateMate.Startup))]
namespace DateMate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
