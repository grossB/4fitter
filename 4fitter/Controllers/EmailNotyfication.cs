using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using _4fitter.Enums;
using _4fitter.Models;

namespace _4fitter.Controllers
{
    public class EmailNotyfication
    {
        public void NewMealCalcWithDayOfWeekModel()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ApplicationDbContext dbDayOfWeekMeal = new ApplicationDbContext();

            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            foreach (var bmrUser in db.BmrCalculators)
            {
                string userID = bmrUser.UserId;
                TargetTypeEnum dietTarget = bmrUser.TargetType;

                int dietTargetExtraCalories = dietTarget == TargetTypeEnum.Bulk ? 50 : dietTarget == TargetTypeEnum.Reduction ? -50 : 0;
                var userEmail = manager.Users.Where(x => x.Id == userID).Select(x => x.Email);

                var dayOfWeek = (int)DateTime.Now.DayOfWeek;

                var mealOfTheDay = dbDayOfWeekMeal.DayOfWeeks.ToList().ElementAt(dayOfWeek);
                var calories = CalcCalories(mealOfTheDay.Meals).Item1;

                var multi = (bmrUser.BaseCalories + (dietTargetExtraCalories * dayOfWeek)) / calories;

                foreach (var meal in mealOfTheDay.Meals)
                {
                    foreach (var ingredient in meal.Ingredients)
                    {
                        ingredient.Calories = (int)(ingredient.Calories * multi);
                    }
                }

                var mealNewValues = CalcCalories(mealOfTheDay.Meals, multi);

                var newcalories = mealNewValues.Item1;
                var mealInformation = mealNewValues.Item2;

                //TODO Email notification with those calculated data
            }
        }

        private Tuple<int, string> CalcCalories(ICollection<Meal> meals, double multi = 1)
        {
            StringBuilder message = new StringBuilder();
            var calories = 0;
            foreach (var meal in meals)
            {
                message.Append($"{meal.Name}\n");
                foreach (var ingredients in meal.Ingredients)
                {
                    calories += ingredients.Calories;
                    message.Append($"{ ingredients.Name} {ingredients.Calories} Carbo: {ingredients.Carbohydrates * multi} Prot {ingredients.Proteins * multi} Fats{ingredients.Fats * multi} \n");
                }

            }
            var result = new Tuple<int, string>(calories, message.ToString());
            return result;
        }

    }
}