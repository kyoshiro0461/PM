using PM.Models;
using PMBLL.Instance;
using PMModel;
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
            InitialPC();
           

        }
        /// <summary>
        /// PC端初始化
        /// </summary>
        void InitialPC()
        {
            MenuFactory menufactory = new MenuFactory();
            List<IMenuB> lstMenu = menufactory.GetDataMenu();
            List<MenuM> MenuInfo = new List<MenuM>();
            if (lstMenu != null && lstMenu.Count > 0) lstMenu.ForEach(p => MenuInfo.Add(p.Infomation_menu));
            ViewBag.BaseMenuInfo = MenuInfo;
        }


    }
}