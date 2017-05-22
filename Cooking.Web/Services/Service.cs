using Cooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cooking.Web.Services
{
    public class Service
    {
        public Service()
        {
            this.Context = new CoockingDBContext();
        }
        internal CoockingDBContext Context { get; set; }
        internal bool IfRecipeExist(int id)
        {
            return this.Context.Recipes.Any(r => r.Id == id);
        }
    }
}