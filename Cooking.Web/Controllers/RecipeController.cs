using Cooking.Models.BindModels.Site;
using Cooking.Models.EntityModels;
using Cooking.Models.ViewModels.Site;
using Cooking.Web.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cooking.Web.Controllers
{
    [RoutePrefix("Recipe")]
    public class RecipeController : Controller
    {
        private RecipeService service;

        public RecipeController()
        {
            this.service = new RecipeService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("New")]
        public ActionResult New()
        {
            NewRecipeVM model = new NewRecipeVM();
            model.Types = this.service.GetRecipeTypes();
            return View(model);
        }

        [HttpPost]
        [Route("New")]
        public ActionResult New(NewRecipeBM bind, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                int recId = this.service.CreateNewRecipe(bind, userId, fileUpload);
                return RedirectToAction("Editor", "Recipe", new { id = recId });
            }
            NewRecipeVM model = new NewRecipeVM();
            model.Types = this.service.GetRecipeTypes();
            return View(model);
        }

        [HttpGet]
        [Route("{id:int}/Editor")]
        public ActionResult Editor(int id)
        {
            if (!this.service.IfRecipeExist(id))
            {
                return HttpNotFound();
            }
            EditorVM model = this.service.GetRecipe(id);
            return View(model);
        }

        [Route("{id:int}/Delete")]
        public ActionResult Delete(int id)
        {
            if (!this.service.IfRecipeExist(id))
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                this.service.DeleteRecipe(id);
            }
            return View();
        }

        [HttpGet]
        [Route("{id:int}/Edit")]
        public ActionResult Edit(int id)
        {
            if (!this.service.IfRecipeExist(id))
            {
                return HttpNotFound();
            }
            NewRecipeVM model = this.service.RecipeToNewEditVM(id);
            return View(model);
        }

        [HttpPost]
        [Route("{id:int}/Edit")]
        public ActionResult Edit(int id, NewRecipeBM bind)
        {
            if (!this.service.IfRecipeExist(id))
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                this.service.EditRecipeMainContent(bind, id);
                return RedirectToAction("Editor", "Recipe", new { id = id });
            }
            return View();
        }

        [HttpGet]
        [Route("{id:int}/RemoveImg")]
        public ActionResult RemoveImg(int id)
        {
            if (!this.service.IfRecipeExist(id))
            {
                return HttpNotFound();
            }
            this.service.RemoveReceptImg(id);
            return RedirectToAction("Edit","Recipe", new { id=id });
        }

        [HttpGet]
        [Route("{id:int}/Viewer")]
        public ActionResult Viewer(int id)
        {
            if (!this.service.IfRecipeExist(id))
            {
                return HttpNotFound();
            }
            Recipe recipe = this.service.GetRecipeById(id);
            return View(recipe);
        }

        [HttpPost]
        [Route("{id:int}/Comment")]
        public ActionResult MakeComment(MakeCommentBM bind)
        {
            if (!this.service.IfRecipeExist(bind.Id))
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                this.service.AddCommentToRecipe(bind, userId);
            }
            return RedirectToAction("Viewer", "Recipe", new { id = bind.Id });
        }

    }
}