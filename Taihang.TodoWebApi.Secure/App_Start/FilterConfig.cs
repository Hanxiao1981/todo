using System.Web;
using System.Web.Mvc;

namespace Taihang.TodoWebApi.Secure
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
