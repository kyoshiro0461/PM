using System.Web;
using System.Web.Mvc;

namespace PM
{
    /// <summary>
    /// 过滤配置类
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// 全局过滤器
        /// </summary>
        /// <param name="filters">全局过滤集合</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

