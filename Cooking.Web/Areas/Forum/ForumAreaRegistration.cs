using System.Web.Mvc;

namespace Cooking.Web.Areas.Forum
{
    public class ForumAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Forum";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapMvcAttributeRoutes();

            //context.MapRoute(
            //    "Forum_default",
            //    "Forum/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional },
            //    new { controller = "Discussion" },
            //    new[] { "Cooking.Web.Areas.Forum.Controllers" }
            //);
        }
    }
}