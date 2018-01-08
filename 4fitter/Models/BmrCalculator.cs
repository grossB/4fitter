using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using _4fitter.Enums;

namespace _4fitter.Models
{
    public class BmrCalculator
    {
        public int ID { get; set; }

        public string UserId { get; set; }

        public double Weight { get; set; }

        public ActivityTypeEnum Activity { get; set; }

        public Sex SexType { get; set; }

        public DateTime DateTime { get; set;
            //get { return DateTime.Now; }
            //set { this.DateTime = value; }
        }

        public bool Notification { get; set; }

        public TargetTypeEnum TargetType { get; set; }

        [Range(1, 12, ErrorMessage = "Value should be beetween 1-12")]
        public int NumberOfWeeks { get; set; }

        [Range(1, 230, ErrorMessage = "Value should be beetween 1-230")]
        public int Height { get; set; }

        [Range(1, 99, ErrorMessage = "Value should be beetween 1-99")]
        public int Age { get; set; }

        public double BaseCalories { get; set; }
    }
}