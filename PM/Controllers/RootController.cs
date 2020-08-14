using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.Controllers
{
    /// <summary>
    /// 根控制器(wap)
    /// </summary>
    public abstract class RootController : Controller
    {
        /// <summary>
        /// 执行Action中
        /// </summary>
        /// <param name="filterContext">控制器上下文</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

           

        }
       

    }
}