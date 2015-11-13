using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReportApp.Startup))]
namespace ReportApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
