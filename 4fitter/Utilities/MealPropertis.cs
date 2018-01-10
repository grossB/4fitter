using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _4fitter.Models;

namespace _4fitter.Utilities
{
    public class MealPropertis
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        private int calories;
        private int proteins;
        private int fat;
        private int grams;


        public string Calculatorek()
        {
            db = ApplicationDbContext.Create();
            var meals = db.Meals;
            var ingredients = meals.ElementAt(0).Ingredients;

            foreach (var ingredient in ingredients)
            {
                calories += ingredient.Calories;
                proteins += ingredient.Proteins;
                grams += ingredient.Grams;
                fat += ingredient.Fats;
            }

            return $"calories = {calories}, proteins= {proteins}, fat= {fat}, grams= {grams}";
        }
    }
}