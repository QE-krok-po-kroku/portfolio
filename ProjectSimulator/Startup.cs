using Owin;
using System.Web.Http;

namespace ProjectSimulator
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = new HttpConfiguration();

            webApiConfiguration.MapHttpAttributeRoutes();

            app.UseWebApi(webApiConfiguration);
        }
    }
}
