using System.Web.Mvc;
using System.Web.Routing;

namespace QLDoDungTreEm
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
            name: "ADD TO CART",
            url: "ThemGioHang",
            defaults: new { controller = "ShopCart", action = "ThemGioHang", id = UrlParameter.Optional },
            namespaces: new[] { "QLDoDungTreEm.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "TrangChu", id = UrlParameter.Optional },
                namespaces: new[] { "QLDoDungTreEm.Controllers" }
            );
        }
    }
}