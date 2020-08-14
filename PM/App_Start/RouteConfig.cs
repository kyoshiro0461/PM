using PM.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PM
{
    /// <summary>
    /// 路由配置
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="routes">路由集合</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            CommonParams.Init = new Initialization();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Initial", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
