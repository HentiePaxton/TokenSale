using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoinListing.Startup))]
namespace CoinListing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
