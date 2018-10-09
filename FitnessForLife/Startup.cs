using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessForLife.Startup))]
namespace FitnessForLife
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
