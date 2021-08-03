using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Add global Authorization
            filters.Add(new AuthorizeAttribute());

            // Remove URL from http channel
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
