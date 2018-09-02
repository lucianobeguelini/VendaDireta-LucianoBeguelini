using System.Web;
using System.Web.Mvc;
using VendaDireta.Models;

namespace VendaDireta
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new FilterSessao());
        }
    }
}
