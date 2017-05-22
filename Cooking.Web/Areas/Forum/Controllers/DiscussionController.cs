using Cooking.Models.BindModels.Forum;
using Cooking.Models.ViewModels.Forum;
using Cooking.Web.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cooking.Web.Areas.Forum.Controllers
{
    [Authorize]
    [RouteArea("Forum")]
    [RoutePrefix("Discussion")]
    public class DiscussionController : Controller
    {
        // GET: Forum/Discussion
        private ForumService service;
        public DiscussionController()
        {
            this.service = new ForumService();
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<ForumIndexViewModel> model = this.service.GetAllDiscussions();

            return View(model);
        }

        [HttpGet]
        [Route("Search/{search?}")]
        public ActionResult Search(string search)
        {
            IEnumerable<ForumIndexViewModel> model = this.service.CetDiscussionsFromSearch(search);
            return View(model);
        }

        [HttpGet]
        [Route("{id:int}/Ditails")]
        public ActionResult Details(int id)
        {
            DiscussonDetailsVm model = this.service.GetDiscussuonById(id);
            return View(model);
        }

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(CreateDiscussionBM bm)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                this.service.CreateDiscussion(bm, userId);
                return this.RedirectToAction("index", "Discussion");
            }
            return View();
        }

        [HttpPost]
        [Route("{id:int}/Post")]
        public ActionResult Post(MakePostBM bind)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                this.service.CreatePost(bind, userId);
            }
            return this.RedirectToAction("Details", "Discussion");
        }
    }
}