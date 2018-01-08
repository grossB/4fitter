using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4fitter.Models
{
    public class Ingredient
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public short Proteins { get; set; }

        public short Fats { get; set; }

        public short Carbohydrates { get; set; }

        public int Grams { get; set; }

        public int Calories { get; set; }

        public virtual ICollection<Meal> Meal { get; set; }

        public Ingredient()
        {
            this.Meal = new HashSet<Meal>();
        }
    }
}