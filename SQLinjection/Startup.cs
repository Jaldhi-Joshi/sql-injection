using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SQLinjection.Startup))]
namespace SQLinjection
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
