using Cooking.Models.BindModels.Site;
using Cooking.Models.ViewModels.Site;
using Cooking.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cooking.Web.Controllers
{
    [RoutePrefix("Recipe/{recipeid:int}")]
    public class ProductController : Controller
    {
        private RecipeService service;
        public ProductController()
        {
            this.service = new RecipeService();
        }

        [HttpGet]
        [Route("AddProduct")]
        public ActionResult AddProduct(int recipeid)
        {
            if (!this.service.IfRecipeExist(recipeid))
            {
                return HttpNotFound();
            }
            ProductVM model = new ProductVM();
            model.Id = recipeid;
            return View(model);
        }

        [HttpPost]
        [Route("AddProduct")]
        public ActionResult AddProduct(AddProductsBM bind)
        {
            if (!this.service.IfRecipeExist(bind.Id))
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                this.service.AddProductToRecipe(bind);
                return RedirectToAction("Editor", "Recipe", new { id = bind.Id });
            }
            ProductVM model = new ProductVM();
            model.Id = bind.Id;
            return View(model);
        }

        [HttpGet]
        public ActionResult EditProduct(EditDelProductBM bind)
        {
            if (!this.service.IfRecipeExist(bind.recipeid))
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                ProductVM model = this.service.GetRecipeProduct(bind);
                return View(model);
            }
            return RedirectToAction("Editor", "Recipe", new { id = bind.recipeid });
        }

        [HttpPost]
        [Route("EditProduct")]
        public ActionResult EditProduct(EditProductBM model)
        {
            if (!this.service.IfRecipeExist(model.Id))
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                this.service.EditRecipeProduct(model);
            }
            return RedirectToAction("Editor", "Recipe", new { id = model.Id });
        }

        public ActionResult DeleteProduct(EditDelProductBM bind)
        {
            if (!this.service.IfRecipeExist(bind.recipeid))
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                this.service.DeleteProduct(bind);
            }
            return RedirectToAction("Editor", "Recipe", new { id = bind.recipeid });
        }
    }

}