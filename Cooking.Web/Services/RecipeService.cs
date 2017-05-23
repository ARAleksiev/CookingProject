using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cooking.Models.EntityModels;
using Cooking.Models.BindModels.Site;
using System.IO;
using Cooking.Models.ViewModels.Site;
using AutoMapper;
using Cooking.Models.Enums;
using System.Data.Entity;

namespace Cooking.Web.Services
{
    public class RecipeService : Service
    {
        internal int CreateNewRecipe( NewRecipeBM bind, string userId, HttpPostedFileBase fileUpload)
        {
            
            var user = Context.Users.FirstOrDefault(u => u.Id == userId);
            var recipeType = this.Context.ReceptTypes.FirstOrDefault(rt=>rt.Id == bind.SelectedTypesId);

            Recipe recipe = new Recipe()
            {
                Description = bind.Description,
                Title = bind.Title,
                Type = recipeType,
                Country = bind.Country,
                Author = user,
                Serves = bind.Serves,
                CookingHour = bind.CookingHour,
                CookingMinutes = bind.CookingMinutes
            };

            if (fileUpload != null)
            {
                this.SaveImgInFileSystem(fileUpload, recipe);
            }

            this.Context.Recipes.Add(recipe);
            this.Context.SaveChanges();

            return recipe.Id;
        }

        internal IEnumerable<RecipeTypeVM> GetRecipeTypes()
        {
            IEnumerable<ReceptType> types = this.Context.ReceptTypes;
            IEnumerable<RecipeTypeVM> vm = Mapper.Instance.Map<IEnumerable<ReceptType>,
                                                                      IEnumerable<RecipeTypeVM>>(types);
            return vm;
          
        }
        private void SaveImgInFileSystem(HttpPostedFileBase fileUpload, Recipe recipe)
        {
            string dirGUID = Guid.NewGuid().ToString().Replace("-", "");
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Images/Recipe/" + dirGUID));
            var fileName = Path.GetFileName(fileUpload.FileName);
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Recipe/" + dirGUID), fileName);
            fileUpload.SaveAs(path);
            recipe.DirectoryCUID = dirGUID;
            recipe.ProfilImg = fileName;
        }

        internal void DeleteRecipe(int id)
        {
            var rec = this.Context.Recipes.FirstOrDefault(r=>r.Id==id);
            if (rec != null)
            {
                this.Context.Recipes.Remove(rec);
                this.Context.SaveChanges();
            }
        }

        internal NewRecipeVM RecipeToNewEditVM(int id)
        {
            var rec = this.Context.Recipes.FirstOrDefault(r=>r.Id==id);
            NewRecipeVM vm = new NewRecipeVM();
            if (rec !=null)
            {
                vm.Id = rec.Id;
                vm.Description = rec.Description;
                vm.Country = rec.Country;
                vm.ProfilImgGUID = rec.ProfilImg;
                vm.SelectedTypesId = rec.Type.Id;
                vm.Title = rec.Title;
                vm.Types = this.GetRecipeTypes();
                vm.Dir = rec.DirectoryCUID;
            }
            return vm;
        }

        internal void EditRecipeMainContent(NewRecipeBM bind, int id)
        {
            var rec = this.Context.Recipes.FirstOrDefault(r => r.Id == id);
            var recipeType = this.Context.ReceptTypes.FirstOrDefault(rt => rt.Id == bind.SelectedTypesId);
            if (rec != null)
            {
                rec.Country = bind.Country;
                rec.Description = bind.Description;
                rec.Type = recipeType;
                rec.Title = bind.Title;
                if (bind.fileUpload != null)
                {
                    this.SaveImgInFileSystem(bind.fileUpload, rec);
                }
                this.Context.SaveChanges();
            }
        }

        internal Recipe GetRecipeById(int id)
        {
            return this.Context.Recipes.FirstOrDefault(r=>r.Id == id);
        }

        internal void RemoveReceptImg(int id)
        {

            var recipe = this.Context.Recipes.FirstOrDefault(r=>r.Id==id);
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/Recipe/" + recipe.DirectoryCUID), recipe.ProfilImg);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (recipe != null)
            {
                recipe.ProfilImg = string.Empty;
                this.Context.SaveChanges();
            }


        }

        internal void AddCommentToRecipe(MakeCommentBM bind, string userId)
        {
            var rec = this.Context.Recipes.FirstOrDefault(r => r.Id == bind.Id);
            var user = Context.Users.FirstOrDefault(u => u.Id == userId);
            Comment comment = new Comment()
            {
                Title = bind.Title,
                Content = bind.Content,
                DateCreated = DateTime.Now,
                Author = user
            };
            rec.Comments.Add(comment);
            this.Context.SaveChanges();
        }

        internal EditorVM GetRecipe(int id)
        {
            Recipe recipe = this.Context.Recipes.FirstOrDefault(r=>r.Id == id);
            EditorVM vm = new EditorVM();
            if (recipe != null)
            {
                vm = Mapper.Instance.Map<Recipe, EditorVM>(recipe);
            }
            
            return vm;
        }

        internal void AddProductToRecipe(AddProductsBM bind)
        {
            var recipe = this.Context.Recipes.FirstOrDefault(r=>r.Id == bind.Id);
            Measures measures = (Measures)bind.Measures;
            Product product = new Product()
            {
                Name = bind.Name,
                Quantity = bind.Quantity,
                Measure = measures.ToString(),
                Recipe = recipe
            };
            this.Context.Products.Add(product);
            this.Context.SaveChanges();
        }

        internal ProductVM GetRecipeProduct(EditDelProductBM bind)
        {
            var product = 
                this.Context.Products.FirstOrDefault(p=>p.Id == bind.productid && p.Recipe.Id == bind.recipeid);
            ProductVM vm = new ProductVM()
            {
                 Id = product.Recipe.Id,
                 ProductId = bind.productid,
                 Name = product.Name,
                 Quantity = product.Quantity,
                 Measures = (Measures)Enum.Parse(typeof(Measures), product.Measure)
            };
            return vm;
        }

        internal void EditRecipeProduct(EditProductBM model)
        {
            var product = this.Context.Products.FirstOrDefault(p => p.Id == model.ProductId);
            if (product != null)
            {
                Measures measures = (Measures)model.Measures;
                product.Name = model.Name;
                product.Quantity = model.Quantity;
                product.Measure = measures.ToString();

                this.Context.SaveChanges();
            }

        }

        internal void DeleteProduct(EditDelProductBM bind)
        {
            var product = 
                this.Context.Products.FirstOrDefault(p => p.Id == bind.productid && p.Recipe.Id == bind.recipeid);
            if (product != null)
            {
                this.Context.Products.Remove(product);
                this.Context.SaveChanges();
            }
        }
    }
}