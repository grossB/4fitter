using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _4fitter.Enums;

namespace _4fitter.Utilities
{
    public class RandomUtils
    {

        public int TargetBasedBonusCalories(TargetTypeEnum target)
        {
            switch (target)
            {
                case TargetTypeEnum.Bulk:
                    return 200;
                case TargetTypeEnum.Maintain:
                    return 0;
                case TargetTypeEnum.Reduction:
                    return -300;
                default:
                    throw new ArgumentOutOfRangeException(nameof(target), target, null);
            }
        }

        public int SexBasedBonusCalories(Sex gender)
        {
            var result = gender == Sex.Male ? 100 : -260;
            return result;
        }

        public double ActivityMultiplier(ActivityTypeEnum activity)
        {
            switch (activity)
            {
                case ActivityTypeEnum.NoExerciseOfficeWork:
                    return 1.2;
                case ActivityTypeEnum.Light:
                    return 1.4;
                case ActivityTypeEnum.Moderate:
                    return 1.6;
                case ActivityTypeEnum.High:
                    return 1.75;
                case ActivityTypeEnum.VeryHigt:
                    return 2.1;

                default:
                    return 0;
            }
        }
    }
}