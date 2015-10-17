using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Caloria.Startup))]
namespace Caloria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
