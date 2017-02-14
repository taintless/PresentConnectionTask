using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployersSalary.Startup))]
namespace EmployersSalary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
