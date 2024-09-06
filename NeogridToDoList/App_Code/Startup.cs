using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NeogridToDoList.Startup))]
namespace NeogridToDoList
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
