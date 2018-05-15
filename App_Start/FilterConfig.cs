using System.Web;
using System.Web.Mvc;
using AuctionInventory.MyRoleProvider;

namespace AuctionInventory
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //adding for testing on 28-10-2017 by shahzad
            //filters.Add(new PermissionsAttribute());
        }
    }
}
