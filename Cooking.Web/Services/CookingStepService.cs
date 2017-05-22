using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cooking.Models.BindModels.Site;
using Cooking.Models.EntityModels;
using System.IO;
using Cooking.Models.ViewModels.Site;

namespace Cooking.Web.Services
{
    public class CookingStepService : Service
    {
        internal void AddStepToRecipe(CookStepBM bind)
        {
            var recipe = this.Context.Recipes.FirstOrDefault(r => r.Id == bind.RecipeId);
            CookingStep step = new CookingStep();
            if (bind.fileUpload != null)
            {
                var fileName = Path.GetFileName(bind.fileUpload.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Recipe/" + recipe.DirectoryCUID), fileName);
                bind.fileUpload.SaveAs(path);
                step.Img = fileName;
            }
            step.Description = bind.Description;
            step.Recept = recipe;
            this.Context.Steps.Add(step);
            this.Context.SaveChanges();
        }

        internal void DeleteStep(EditDelCookStep bind)
        {
            var step = this.Context.Steps.FirstOrDefault(p => p.Id == bind.CookStepId && p.Recept.Id == bind.RecipeId);
            if (step != null)
            {
                this.Context.Steps.Remove(step);
                this.Context.SaveChanges();
            }
        }

        internal CookingStep LoadStep(EditDelCookStep bind)
        {
            return this.Context.Steps.FirstOrDefault(s=>s.Id==bind.CookStepId);
        }

        internal void EditCookStep(CookStepBM bind, int cookStepId)
        {
            var step = this.Context.Steps.FirstOrDefault(s=>s.Id == cookStepId);
            if (step != null)
            {
                step.Description = bind.Description;
                if (bind.fileUpload != null)
                {
                    var recipe = this.Context.Recipes.FirstOrDefault(r => r.Id == bind.RecipeId);
                    var fileName = Path.GetFileName(bind.fileUpload.FileName);
                    var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Recipe/" + recipe.DirectoryCUID), fileName);
                    bind.fileUpload.SaveAs(path);
                    step.Img = fileName;
                }
                this.Context.SaveChanges();
            }

        }

        internal void RemoveCookStepImg(int recipeid, int step)
        {
            var recipe = this.Context.Recipes.FirstOrDefault(r => r.Id == recipeid);
            CookingStep stepImg = recipe.Steps.FirstOrDefault(s=>s.Id == step);
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Recipe/" + recipe.DirectoryCUID), stepImg.Img);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (recipe != null || stepImg != null)
            {
                stepImg.Img = string.Empty;
                this.Context.SaveChanges();
            }
        }
    }
}