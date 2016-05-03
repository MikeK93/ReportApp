using Microsoft.Owin;
using Owin;
using ReportApp.WebApp;

[assembly: OwinStartup(typeof(Startup))]
namespace ReportApp.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
