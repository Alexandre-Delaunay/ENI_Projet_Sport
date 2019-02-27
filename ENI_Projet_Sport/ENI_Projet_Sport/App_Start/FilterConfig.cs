using System.Web;
using System.Web.Mvc;

namespace ENI_Projet_Sport
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
