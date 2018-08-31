using System.Web;
using System.Web.Mvc;
using Web.Business;

namespace Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new UrlAuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
