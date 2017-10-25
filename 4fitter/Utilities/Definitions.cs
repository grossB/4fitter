using System.Collections.Generic;

namespace _4fitter.Utilities
{
    public class Definitions
    {
        public const string ROLE_ADMIN = "Admin";

        public static List<string> GetOperationTypes()
        {
            return new List<string>
            {
                "Create",
                "Details",
                "Details",
                "Index",
                "Edit"
            };
        }
    }
}