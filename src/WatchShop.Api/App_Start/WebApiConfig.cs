﻿using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Net.Http.Formatting;
using Hal.Engine;
using WatchShop.Api.Infrastructure;
using WatchShop.Api.Catalog;

namespace WatchShop.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "StartPage",
                routeTemplate: "",
                defaults: new { controller = "home", id = RouteParameter.Optional });

            CatalogRouters.Map(config.Routes);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "home", id = RouteParameter.Optional });

            config.Services.Replace(typeof(IHttpControllerSelector), new DomainHttpControllerSelector(config));

            ConfigureFormatters();
        }

        private static void ConfigureFormatters()
        {
            MediaTypeFormatterCollection formatters = GlobalConfiguration.Configuration.Formatters;

            GlobalConfiguration.Configuration.Formatters.Remove(formatters.XmlFormatter);
            GlobalConfiguration.Configuration.Formatters.Remove(formatters.JsonFormatter);
            GlobalConfiguration.Configuration.Formatters.Add(new JsonHalMediaTypeFormatter());
        }
    }
}