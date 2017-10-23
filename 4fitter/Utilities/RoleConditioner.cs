using System.Web.Mvc;

namespace _4fitter.Utilities
{
    public static class RoleConditioner
    {
        public static MvcHtmlString If(this MvcHtmlString value, bool evaluation)
        {
            return evaluation ? value : MvcHtmlString.Empty;
        }
    }
}