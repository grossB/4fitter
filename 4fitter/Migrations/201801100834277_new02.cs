namespace _4fitter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BmrCalculators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Weight = c.Double(nullable: false),
                        Activity = c.Int(nullable: false),
                        SexType = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Notification = c.Boolean(nullable: false),
                        TargetType = c.Int(nullable: false),
                        NumberOfWeeks = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        BaseCalories = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DayOfWeeks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DayOfWeek_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DayOfWeeks", t => t.DayOfWeek_ID)
                .Index(t => t.DayOfWeek_ID);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Proteins = c.Short(nullable: false),
                        Fats = c.Short(nullable: false),
                        Carbohydrates = c.Short(nullable: false),
                        Grams = c.Int(nullable: false),
                        Calories = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OneRepMaxes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Weight = c.Short(nullable: false),
                        Repetitions = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IngredientMeals",
                c => new
                    {
                        Ingredient_ID = c.Int(nullable: false),
                        Meal_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ingredient_ID, t.Meal_ID })
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_ID, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.Meal_ID, cascadeDelete: true)
                .Index(t => t.Ingredient_ID)
                .Index(t => t.Meal_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meals", "DayOfWeek_ID", "dbo.DayOfWeeks");
            DropForeignKey("dbo.IngredientMeals", "Meal_ID", "dbo.Meals");
            DropForeignKey("dbo.IngredientMeals", "Ingredient_ID", "dbo.Ingredients");
            DropIndex("dbo.IngredientMeals", new[] { "Meal_ID" });
            DropIndex("dbo.IngredientMeals", new[] { "Ingredient_ID" });
            DropIndex("dbo.Meals", new[] { "DayOfWeek_ID" });
            DropTable("dbo.IngredientMeals");
            DropTable("dbo.OneRepMaxes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Meals");
            DropTable("dbo.DayOfWeeks");
            DropTable("dbo.BmrCalculators");
        }
    }
}
