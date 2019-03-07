using AutoParking.Models;
using AutoParking.Token;
using AutoParking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AutoParking
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Filters.Add(new ValidateModelAttribute());


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
