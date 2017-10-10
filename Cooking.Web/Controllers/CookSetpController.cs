using Cooking.Models.BindModels.Site;
using Cooking.Models.EntityModels;
using Cooking.Models.ViewModels.Site;
using Cooking.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cooking.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Recipe/{recipeid:int}")]
    public class CookSetpController : Controller
    {
        private CookingStepService service;
        public CookSetpController()
        {
            this.service = new CookingStepService();
        }

        [HttpGet]
        [Route("AddStep")]
        public ActionResult AddStep(int recipeid)
        {
            if (!this.service.IfRecipeExist(recipeid))
            {
                return HttpNotFound();
            }
            AddStepVM model = new AddStepVM();
            model.RecipeId = recipeid;
            return View(model);
        }

        [HttpPost]
        [Route("AddStep")]
        public ActionResult AddStep(CookStepBM bind)
        {
            if (!this.service.IfRecipeExist(bind.RecipeId))
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                this.service.AddStepToRecipe(bind);
                return RedirectToAction("Editor", "Recipe", new { id = bind.RecipeId });
            }

            return View();
        }
        [HttpGet]
        [Route("EditCookStep/{cookStepId:int}")]
        public ActionResult EditCookStep(EditDelCookStep bind)
        {
            if (!this.service.IfRecipeExist(bind.RecipeId))
            {
                return HttpNotFound();
            }
            CookingStep model = new CookingStep();
            if (ModelState.IsValid)
            {
                 model =  this.service.LoadStep(bind);
                return View(model);
            }
            return RedirectToAction("Editor", "Recipe", new { id = bind.RecipeId });
        }
        [HttpPost]
        [Route("EditCookStep/{cookStepId:int}")]
        public ActionResult EditCookStep(CookStepBM bind, int cookStepId)
        {
            if (!this.service.IfRecipeExist(bind.RecipeId))
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                this.service.EditCookStep(bind, cookStepId);
                return RedirectToAction("Editor", "Recipe", new { id = bind.RecipeId });
            }
            return View();
        }
        [Route("DeleteCookStep/{cookStepId:int}")]
        public ActionResult DeleteCookStep(EditDelCookStep bind)
        {
            if (!this.service.IfRecipeExist(bind.RecipeId))
            {
                return HttpNotFound();
            }
            this.service.DeleteStep(bind);
                return RedirectToAction("Editor", "Recipe", new { id = bind.RecipeId });
        }
        [Route("RemoveCookStepImg/{step:int}")]
        public ActionResult RemoveCookStepImg(int recipeid, int step)
        {
            if (!this.service.IfRecipeExist(recipeid))
            {
                return HttpNotFound();
            }
            this.service.RemoveCookStepImg(recipeid, step);
            return RedirectToAction("EditCookStep", "CookSetp", new { recipeid = recipeid , cookStepId = step });
        }
    }
}