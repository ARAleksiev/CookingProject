using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cooking.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Cooking.Web.Controllers" }
            );

            routes.MapRoute(
                name: "RoductRoute",
                url: "Recipe/{recipeid}/{action}",
                defaults: new { controller = "Product", action = "AddProduct", recipeid = UrlParameter.Optional},
                namespaces: new string[] { "Cooking.Web.Controllers" }
            );

            routes.MapRoute(
                name: "RoductEdit",
                url: "Recipe/{recipeid}/{action}/{productid}",
                defaults: new { controller = "Product", action = "EditProduct", recipeid = UrlParameter.Optional, productid = UrlParameter.Optional },
                namespaces: new string[] { "Cooking.Web.Controllers" }
            );

            routes.MapRoute(
                name: "CookStepEditDelete",
                url: "Recipe/{recipeid}/{action}/{cookStepId}",
                defaults: new { controller = "CookSetp", action = "EditCookStep", recipeid = UrlParameter.Optional, cookStepId = UrlParameter.Optional },
                namespaces: new string[] { "Cooking.Web.Controllers" }
            );
        }
    }
}
