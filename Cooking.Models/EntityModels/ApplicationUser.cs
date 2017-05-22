using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cooking.Models.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Recipes = new HashSet<Recipe>();
            this.Articles = new HashSet<Article>();
            this.Comments = new HashSet<Comment>();
            this.Posts = new HashSet<Post>();
            this.Votes = new HashSet<Vote>();
            this.Favorites = new HashSet<Favorite>();
        }
        public double Rating { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
