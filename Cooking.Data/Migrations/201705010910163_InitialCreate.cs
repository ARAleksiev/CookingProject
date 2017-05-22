namespace Cooking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DirectoryCUID = c.String(),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Rating = c.Double(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                        Recipe_Id = c.Int(),
                        Post_Id = c.Int(),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Recipe_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Recipe_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Rating = c.Double(nullable: false),
                        ProfilImg = c.String(),
                        DirectoryCUID = c.String(),
                        Country = c.String(),
                        Author_Id = c.String(maxLength: 128),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.ReceptTypes", t => t.Type_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Measure = c.String(),
                        Quantity = c.Double(nullable: false),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.CookingSteps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Img = c.String(),
                        Recept_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recept_Id)
                .Index(t => t.Recept_Id);
            
            CreateTable(
                "dbo.ReceptTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                        Discussion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.Discussions", t => t.Discussion_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Discussion_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Recept_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recept_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Recept_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Discussions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Creator_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .Index(t => t.Creator_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Posts", "Discussion_Id", "dbo.Discussions");
            DropForeignKey("dbo.Discussions", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Votes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Votes", "Recept_Id", "dbo.Recipes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "Type_Id", "dbo.ReceptTypes");
            DropForeignKey("dbo.CookingSteps", "Recept_Id", "dbo.Recipes");
            DropForeignKey("dbo.Products", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Comments", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articles", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Discussions", new[] { "Creator_Id" });
            DropIndex("dbo.Votes", new[] { "User_Id" });
            DropIndex("dbo.Votes", new[] { "Recept_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "Discussion_Id" });
            DropIndex("dbo.Posts", new[] { "Author_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.CookingSteps", new[] { "Recept_Id" });
            DropIndex("dbo.Products", new[] { "Recipe_Id" });
            DropIndex("dbo.Recipes", new[] { "Type_Id" });
            DropIndex("dbo.Recipes", new[] { "Author_Id" });
            DropIndex("dbo.Favorites", new[] { "User_Id" });
            DropIndex("dbo.Favorites", new[] { "Recipe_Id" });
            DropIndex("dbo.Comments", new[] { "Article_Id" });
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropIndex("dbo.Comments", new[] { "Recipe_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Articles", new[] { "Author_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Discussions");
            DropTable("dbo.Votes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Posts");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.ReceptTypes");
            DropTable("dbo.CookingSteps");
            DropTable("dbo.Products");
            DropTable("dbo.Recipes");
            DropTable("dbo.Favorites");
            DropTable("dbo.Comments");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Articles");
        }
    }
}
