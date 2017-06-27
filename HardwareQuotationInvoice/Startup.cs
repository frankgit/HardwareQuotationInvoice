using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HardwareQuotationInvoice.Startup))]
namespace HardwareQuotationInvoice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
