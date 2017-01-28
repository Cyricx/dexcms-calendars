using System.Web.Routing;
using System.Web.Mvc;
using DexCMS.Core.Models;

namespace DexCMS.Calendars.Mvc
{
    public static class CalendarsMvcRoutes
    {
        public static void CreateDefaultRoutes(RouteCollection routes, DexCMSConfiguration config)
        {
            routes.MapRoute(
                name: "Calendar",
                url: "Calendar",
                defaults: new { category = "none", urlSegment = "calendar", controller = "Calendar", action = "Index" });

            routes.MapRoute(
                name: "CalendarSubMethods",
                url: "Calendar/{action}",
                defaults: new { controller = "Calendar" });
        }
    }
}
