﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.Controllers
{

    /// <summary>
    /// 基类控制器（后台管理）
    /// </summary>
    public class AdminBaseController : RootController
    {
        /// <summary>
        /// 后台管理信息控制器
        /// </summary>
        public AdminBaseController()
        {
            //获取顶部后台菜单信息分类
            MenuColFactory menucolfactory = new MenuColFactory();
            List<IMenuB> lstMenu = menucolfactory.GetDataMenu();
            List<MenuM> MenuInfoCol = new List<MenuM>();
            lstMenu.ForEach(p => MenuInfoCol.Add(p.Infomation_menu));
            ViewBag.AdminBaseController = MenuInfoCol;
            ////获取model表信息
            //ModelColFactory modelcolfactory = new ModelColFactory();
            //List<IModelB> lstModel = modelcolfactory.AllGetData();
            //List<ModelM> ModelInfoCol = new List<ModelM>();
            //if (lstModel != null && lstModel.Count > 0) lstModel.ForEach(p => ModelInfoCol.Add(p.Infomation));
            //ViewBag.ModelInfoCol = ModelInfoCol;
            ////提示消息
            //PromptColFactory promptcolfactory = new PromptColFactory();
            //List<IPromptB> lst = promptcolfactory.GetData();
            //List<PromptM> PromptInfoCol = new List<PromptM>();
            //if (lst != null && lst.Count > 0) lst.ForEach(p => PromptInfoCol.Add(p.Infomation));
            //ViewBag.PromptInfoCol = PromptInfoCol;
        }

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