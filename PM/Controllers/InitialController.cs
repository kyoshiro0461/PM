using PM.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.Controllers
{
    /// <summary>
    /// 网站初始化控制器
    /// </summary>
    public class InitialController : Controller
    {
        /// <summary>
        /// Index默认页
        /// </summary>
        /// <returns>跳转页面</returns>
        public ActionResult Index()
        {
            ActionResult result = RedirectToAction("Index", "Main");
            try
            {
                //初始化网站需要的参数
            }
            catch (Exception ex)
            {
                result = Content(ex.Message);
            }

            return result;
        }

    }
}