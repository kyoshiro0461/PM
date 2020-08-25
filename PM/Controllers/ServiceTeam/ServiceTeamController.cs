using PM.Methods;
using PM.Models;
using PMBLL.Instance;
using PMModel;
using PublicMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.Controllers
{
    /// <summary>
    /// 劳务队页面控制器
    /// </summary>
    public class ServiceTeamController : BaseController
    {
        // GET: ServiceTeam
        public ActionResult ServiceTeam()
        {
            int pageSize = 12; //每页要显示的行数 
            string orderby = ViewMethods.GetForm(Request, "OrderBy", CommonEnums.ValueEnum.vlGet);
            if (string.IsNullOrEmpty(orderby)) orderby = "ST_ID";
            int desc = ViewMethods.GetForm(Request, "Desc", CommonEnums.ValueEnum.vlGet).ConvertToInt32();
            int pagecurrent = ViewMethods.GetForm(Request, "Page", CommonEnums.ValueEnum.vlGet).ConvertToInt32();//分页
            pagecurrent = (pagecurrent == 0 ? 1 : pagecurrent);
            object objkeys = ViewMethods.GetForm(Request, "keys", CommonEnums.ValueEnum.vlGet);//搜索内容
            string keys = "";
            if (objkeys != null) keys = objkeys.ToString();

            long start = (pagecurrent - 1) * pageSize;
            string order = orderby;
            OrderType orderway = (desc == 0 ? OrderType.otDesc : OrderType.otAsc);
            long count = 0;

            ServiceTeamFactory serviceteamfactory = new ServiceTeamFactory();
            List<IServiceTeamB> lstserviceteam = serviceteamfactory.GetPageData(ref count, start, pageSize, keys, order, orderway);
            List<ServiceTeamM> serviceteaminfo = new List<ServiceTeamM>();
            if (lstserviceteam != null && lstserviceteam.Count > 0) lstserviceteam.ForEach(p => serviceteaminfo.Add(p.Infomation_serviceteam));
            int totalpages = 0;
            if ((count % pageSize) > 0)
                totalpages = (int)Math.Ceiling((float)((count / pageSize) + 1));
            else
                totalpages = (int)Math.Ceiling((float)(count / pageSize));//算出分页的总数
            ViewBag.TotalPages = totalpages;
            ViewBag.ServiceTeamInfo = serviceteaminfo;
            TempData["OrderBy"] = desc;
            TempData["CurrentPage"] = pagecurrent;
            TempData["keys"] = objkeys;
            return View();
        }

        /// <summary>
        /// ServiceTeam_Add页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult ServiceTeam_Add()
        {
            return View();
        }

        /// <summary>
        /// 添加劳务队信息（ServiceTeam_Add页面）
        /// </summary>
        public ActionResult Add_ServiceTeam()
        {

            ServiceTeamFactory serviceteamfactory = new ServiceTeamFactory();
            //添加劳务队信息
            ServiceTeamM serviceteamm = new ServiceTeamM();
            string serviceteamname = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();

            bool isExist = serviceteamfactory.IsExist_serviceteamname(serviceteamname);
            if (isExist) return ViewMethods.AlertBack("劳务队已存在,请重新确认", "-1");
            serviceteamm.STName = serviceteamname;

            serviceteamfactory.Infomation_serviceteam = serviceteamm;
            serviceteamfactory.Save();
            return ViewMethods.AlertBack("添加劳务队成功！", "../../ServiceTeam/ServiceTeam");
        }

        /// <summary>
        /// 删除劳务队信息（ServiceTeam页面）
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete_ServiceTeam()
        {

            //获取劳务队编号（id）信息
            string uid = ViewMethods.GetForm(Request, "uid", CommonEnums.ValueEnum.vlPost).ToString();
            ServiceTeamM serviceteamm = new ServiceTeamM();
            serviceteamm.STID = uid.ConvertToInt32();
            ServiceTeamFactory serviceteamfactory = new ServiceTeamFactory();
            serviceteamfactory.Infomation_serviceteam = serviceteamm;
            serviceteamfactory.Del_ServiceTeam();
            return new JsonResult() { Data = PublicMethods.JSonHelper<string>.ObjectToJson(new { status = "0", msg = "删除成功" }), ContentType = "json" };
        }

        /// <summary>
        /// 编辑劳务队信息（ServiceTeam_Edit页面）
        /// </summary>
        public ActionResult Edit_ServiceTeam()
        {
            ServiceTeamFactory serviceteamfactory = new ServiceTeamFactory();
            //获取劳务队编号（id）信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();

            IServiceTeamB serviceteamb = serviceteamfactory.GetDataByID(id);
            ServiceTeamM serviceteamm = (serviceteamb == null ? null : serviceteamb.Infomation_serviceteam);
            //编辑劳务队信息
            string serviceteamname = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            serviceteamm.STName = serviceteamname;
            serviceteamfactory.Infomation_serviceteam = serviceteamm;
            ViewBag.ServiceTeamInfo = serviceteamm;
            bool isSuccess = serviceteamfactory.Update();
            if (isSuccess)
                return ViewMethods.AlertBack("修改成功", "../../ServiceTeam/ServiceTeam");
            else
                return ViewMethods.AlertBack("修改失败", "-1");
        }

        /// <summary>
        /// ServiceTeam_Edit页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult ServiceTeam_Edit()
        {

            //获取劳务队用户（id）数据信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();
            ServiceTeamFactory serviceteamfactory = new ServiceTeamFactory();
            IServiceTeamB lstServiceTeam = serviceteamfactory.GetDataByID(id);
            ServiceTeamM serviceteamm = (lstServiceTeam != null ? lstServiceTeam.Infomation_serviceteam : null);
            ViewBag.ServiceTeamInfo = serviceteamm;
            return View();
        }


    }
}