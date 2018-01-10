using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4fitter.Models
{
    public class DayOfWeek
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}