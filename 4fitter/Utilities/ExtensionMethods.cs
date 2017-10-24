using System.Web.Mvc;

namespace _4fitter.Utilities
{
    public static class ExtensionMethods
    {
        public static MvcHtmlString CheckIfUserIsInRole(this MvcHtmlString value, bool evaluation)
        {
            return evaluation ? value : MvcHtmlString.Empty;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return value == null || value == string.Empty;
        }
    }
}