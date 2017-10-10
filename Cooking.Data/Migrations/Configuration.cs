namespace Cooking.Data.Migrations
{
    using Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cooking.Data.CoockingDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Cooking.Data.CoockingDBContext context)
        {
            context.ReceptTypes.AddOrUpdate(
                rt => rt.Name,
                new ReceptType { Name = "Chicken" },
                new ReceptType { Name = "Pasta" },
                new ReceptType { Name = "Vegetables" },
                new ReceptType { Name = "Fish" },
                new ReceptType { Name = "Eggs" },
                new ReceptType { Name = "Beef" },
                new ReceptType { Name = "Rice" },
                new ReceptType { Name = "Pork" },
                new ReceptType { Name = "Pizza" },
                new ReceptType { Name = "Fast foot" },
                new ReceptType { Name = "Baking" },
                new ReceptType { Name = "Desserts" },
                new ReceptType { Name = "Drinks" },
                new ReceptType { Name = "Salads" },
                new ReceptType { Name = "Soups" },
                new ReceptType { Name = "Others" }
            );
        }
    }
}
