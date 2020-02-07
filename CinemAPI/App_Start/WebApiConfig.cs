using System.Web.Http;

namespace CinemAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Workaround, should it be here?
            config.Routes.MapHttpRoute(
                name: "Indexes",
                routeTemplate: "api/{controller}/{action=Index}/{id}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "Index"}
            );
        }
    }
}