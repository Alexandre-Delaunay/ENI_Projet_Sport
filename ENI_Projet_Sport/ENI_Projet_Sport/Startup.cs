using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ENI_Projet_Sport.Startup))]
namespace ENI_Projet_Sport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
