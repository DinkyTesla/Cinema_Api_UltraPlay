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

            //TODO: When using anotations this will be removed.
            // config.Routes.MapHttpRoute(
            //name: "GetApi",
            //routeTemplate: "api/{controller}/{id}"
            //);

            // config.Routes.MapHttpRoute(
            // name: "DefaultApi",
            // routeTemplate: "api/{controller}"
            // );

            config.Routes.MapHttpRoute(
             name: "DefaultId",
             routeTemplate: "api/{controller}/{action}",
             defaults: new { action = "Index" }
         );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Index" }
            );

        }
    }
}