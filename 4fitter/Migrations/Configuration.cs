namespace _4fitter.Migrations
{
    using _4fitter.Utilities;
    using _4fitter.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<_4fitter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
			//AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(_4fitter.Models.ApplicationDbContext context)
        {
            //AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
            if (!context.Roles.Any(r => r.Name == Definitions.ROLE_ADMIN))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = Definitions.ROLE_ADMIN };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@4fitter.pl"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@4fitter.pl", Email = "admin@4fitter.pl" };

                manager.Create(user, "Admin!1");
                manager.AddToRole(user.Id, Definitions.ROLE_ADMIN);
            }
            if (!context.Roles.Any(r => r.Name == Definitions.ROLE_User))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = Definitions.ROLE_User };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "user@4fitter.pl"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "user@4fitter.pl", Email = "user@4fitter.pl" };

                manager.Create(user, "User!1");
                manager.AddToRole(user.Id, Definitions.ROLE_User);
            }

            var mealOfTheDay = new List<Models.DayOfWeek>
            {
                new Models.DayOfWeek
                {
                    ID = 1,
                    Name = "Monday",
                    Meals =
                        new List<Meal>
                        {
                            new Meal
                            {
                                ID = 1,
                                Name = "Chicken with Potatoes",
                                Ingredients = new List<Ingredient>
                                {
                                    new Ingredient
                                    {
                                        Calories = 300,
                                        Fats = 10,
                                        Carbohydrates = 20,
                                        Grams = 30,
                                        Name = "Chicken",
                                        Proteins = 111,
                                        ID = 1
                                    },
                                    new Ingredient
                                    {
                                        Calories = 200,
                                        Fats = 5,
                                        Carbohydrates = 30,
                                        Grams = 10,
                                        Name = "Potato",
                                        Proteins = 111,
                                        ID = 2
                                    },
                                }
                            },

                        }
                },

                //*********************************************
                                new Models.DayOfWeek
                {
                    ID = 1,
                    Name = "Tuesday",
                    Meals =
                        new List<Meal>
                        {
                            new Meal
                            {
                                ID = 1,
                                Name = "Chicken with Potatoes",
                                Ingredients = new List<Ingredient>
                                {
                                    new Ingredient
                                    {
                                        Calories = 300,
                                        Fats = 10,
                                        Carbohydrates = 20,
                                        Grams = 30,
                                        Name = "Chicken",
                                        Proteins = 111,
                                        ID = 1
                                    },
                                    new Ingredient
                                    {
                                        Calories = 200,
                                        Fats = 5,
                                        Carbohydrates = 30,
                                        Grams = 10,
                                        Name = "Potato",
                                        Proteins = 111,
                                        ID = 2
                                    },
                                }
                            },

                        }
                },
//*********************************************************
                new Models.DayOfWeek
                {
                    ID = 1,
                    Name = "Wednesday",
                    Meals =
                        new List<Meal>
                        {
                            new Meal
                            {
                                ID = 1,
                                Name = "Chicken with Potatoes",
                                Ingredients = new List<Ingredient>
                                {
                                    new Ingredient
                                    {
                                        Calories = 300,
                                        Fats = 10,
                                        Carbohydrates = 20,
                                        Grams = 30,
                                        Name = "Chicken",
                                        Proteins = 111,
                                        ID = 1
                                    },
                                    new Ingredient
                                    {
                                        Calories = 200,
                                        Fats = 5,
                                        Carbohydrates = 30,
                                        Grams = 10,
                                        Name = "Potato",
                                        Proteins = 111,
                                        ID = 2
                                    },
                                }
                            },

                        }
                },
                //*********************************************************
                new Models.DayOfWeek
                {
                    ID = 1,
                    Name = "Thursday",
                    Meals =
                        new List<Meal>
                        {
                            new Meal
                            {
                                ID = 1,
                                Name = "Chicken with Potatoes",
                                Ingredients = new List<Ingredient>
                                {
                                    new Ingredient
                                    {
                                        Calories = 300,
                                        Fats = 10,
                                        Carbohydrates = 20,
                                        Grams = 30,
                                        Name = "Chicken",
                                        Proteins = 111,
                                        ID = 1
                                    },
                                    new Ingredient
                                    {
                                        Calories = 200,
                                        Fats = 5,
                                        Carbohydrates = 30,
                                        Grams = 10,
                                        Name = "Potato",
                                        Proteins = 111,
                                        ID = 2
                                    },
                                }
                            },

                            new Meal
                            {
                                ID = 1,
                                Name = "Chicken with Chicken",
                                Ingredients = new List<Ingredient>
                                {
                                    new Ingredient
                                    {
                                        Calories = 300,
                                        Fats = 10,
                                        Carbohydrates = 20,
                                        Grams = 30,
                                        Name = "Chicken",
                                        Proteins = 111,
                                        ID = 1
                                    },
                                    new Ingredient
                                    {
                                        Calories = 300,
                                        Fats = 10,
                                        Carbohydrates = 20,
                                        Grams = 30,
                                        Name = "Chicken",
                                        Proteins = 111,
                                        ID = 1
                                    },
                                }
                            },

                        }
                },
            };

            mealOfTheDay.ForEach(s => context.DayOfWeeks.Add(s));
            context.SaveChanges();
        }
    }
}
