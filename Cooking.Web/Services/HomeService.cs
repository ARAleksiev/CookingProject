using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cooking.Models.ViewModels.Site;
using Cooking.Models.EntityModels;

namespace Cooking.Web.Services
{
    public class HomeService : Service
    {
        internal IndexVM LoadHomePageSliders()
        {
            IndexVM model = new IndexVM();
            List<SliderVM> recipesColections = new List<SliderVM>();
            var latest = this.Context.Recipes.OrderByDescending(r=>r.CreateDate).Take(8);
            var beefs = this.Context.Recipes.Where(r => r.Type.Name == "Beef").OrderByDescending(r => r.Rating).ThenByDescending(r => r.CreateDate).Take(8);
            var chickens = this.Context.Recipes.Where(r => r.Type.Name == "Chicken").OrderByDescending(r => r.Rating).ThenByDescending(r => r.CreateDate).Take(8);
            var vegetables = this.Context.Recipes.Where(r => r.Type.Name == "Vegetables").OrderByDescending(r => r.Rating).ThenByDescending(r => r.CreateDate).Take(8);
            var salads = this.Context.Recipes.Where(r => r.Type.Name == "Salads").OrderByDescending(r => r.Rating).ThenByDescending(r => r.CreateDate).Take(8);
            var soups = this.Context.Recipes.Where(r => r.Type.Name == "Soups").OrderByDescending(r => r.Rating).ThenByDescending(r => r.CreateDate).Take(8);
            var fish = this.Context.Recipes.Where(r => r.Type.Name == "Fish").OrderByDescending(r => r.Rating).ThenByDescending(r => r.CreateDate).Take(8);
            recipesColections.Add(this.RecipesCollectionToSliderViewModel(latest,"Latest recipes"));
            recipesColections.Add(this.RecipesCollectionToSliderViewModel(beefs, "Top beefs recipes"));
            recipesColections.Add(this.RecipesCollectionToSliderViewModel(chickens, "Top chickens recipes"));
            recipesColections.Add(this.RecipesCollectionToSliderViewModel(vegetables, "Top vegetables recipes"));
            recipesColections.Add(this.RecipesCollectionToSliderViewModel(salads, "Top salads recipes"));
            recipesColections.Add(this.RecipesCollectionToSliderViewModel(soups, "Top soups recipes"));
            recipesColections.Add(this.RecipesCollectionToSliderViewModel(fish, "Top fish recipes"));
            model.RecipesCollections = recipesColections;
            return model;
        }
        private SliderVM RecipesCollectionToSliderViewModel(IQueryable<Recipe> recipes, string title)
        {
            SliderVM model = new SliderVM();
            model.Heading = title;
            List<Recipe> first = new List<Recipe>();
            List<Recipe> second = new List<Recipe>();
            int count = 0;
            foreach (var item in recipes)
            {
                if (count > 3)
                {
                    second.Add(item);
                    count++;
                    continue;
                }
                first.Add(item);
                count++;
            }
            model.First = first;
            model.Second = second;
            return model;
        }
    }
}