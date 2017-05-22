namespace Cooking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Serves", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "CookingHour", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "CookingMinutes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "CookingMinutes");
            DropColumn("dbo.Recipes", "CookingHour");
            DropColumn("dbo.Recipes", "Serves");
        }
    }
}
