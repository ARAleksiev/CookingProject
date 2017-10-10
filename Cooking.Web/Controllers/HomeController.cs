using Cooking.Models.ViewModels.Site;
using Cooking.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cooking.Web.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;
        public HomeController()
        {
            this.service = new HomeService();
        }
        public ActionResult Index()
        {
            IndexVM model = this.service.LoadHomePageSliders();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}