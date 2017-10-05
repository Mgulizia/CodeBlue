using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeBlue.Startup))]
namespace CodeBlue
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
