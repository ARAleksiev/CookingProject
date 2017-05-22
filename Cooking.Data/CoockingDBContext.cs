namespace Cooking.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CoockingDBContext : IdentityDbContext<ApplicationUser>
    {
        public CoockingDBContext()
            : base("CoockingDBContext")
        {
        }

        public static CoockingDBContext Create()
        {
            return new CoockingDBContext();
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CookingStep> Steps { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ReceptType> ReceptTypes { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

    }
}