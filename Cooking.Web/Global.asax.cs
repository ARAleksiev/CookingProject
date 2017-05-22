using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Cooking.Models.ViewModels.Forum;
using Cooking.Models.EntityModels;
using Cooking.Models.BindModels.Site;
using Cooking.Models.ViewModels.Site;

namespace Cooking.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMappers();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMappers()
        {
            Mapper.Initialize(ex => 
            {
                ex.CreateMap<Discussion, ForumIndexViewModel>()
                                        .ForMember(vm=>vm.PostCount, 
                                                   configurationExpression => 
                                                            configurationExpression.MapFrom(dis=> dis.Posts.Count));
                ex.CreateMap<ApplicationUser, UserVm>();
                ex.CreateMap<Discussion, DiscussonDetailsVm>();
                ex.CreateMap<ReceptType, RecipeTypeVM>();
                ex.CreateMap<Recipe, EditorVM>();
            });
        }
    }
}
