using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ForoApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Autenticar", "UsuarioApi/Autenticar/{email}-{contrasena}",
                new {Controller = "UsuarioApi", Action = "Autenticar" });

            routes.MapRoute("FiltrarPreguntaFecha", "PreguntaApi/FiltrarFecha/{fecha1}-{fecha2}",
                new { Controller = "PreguntaApi", Action = "FiltrarFecha" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
