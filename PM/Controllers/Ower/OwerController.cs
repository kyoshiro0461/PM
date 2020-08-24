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
    /// 业主页面控制器
    /// </summary>
    public class OwerController : BaseController
    {
        // GET: Ower
        public ActionResult Ower()
        {
            int pageSize = 12; //每页要显示的行数 
            string orderby = ViewMethods.GetForm(Request, "OrderBy", CommonEnums.ValueEnum.vlGet);
            if (string.IsNullOrEmpty(orderby)) orderby = "OW_ID";
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
            
            OwerFactory owerfactory = new OwerFactory();
            List<IOwerB> lstower = owerfactory.GetPageData(ref count ,start, pageSize, keys, order, orderway);
            List<OwerM> owerinfo = new List<OwerM>();
            if (lstower != null && lstower.Count > 0) lstower.ForEach(p => owerinfo.Add(p.Infomation_ower));
            int totalpages = 0;
            if ((count % pageSize) > 0)
                totalpages = (int)Math.Ceiling((float)((count / pageSize) + 1));
            else
                totalpages = (int)Math.Ceiling((float)(count / pageSize));//算出分页的总数
            ViewBag.TotalPages = totalpages;
            ViewBag.OwerInfo = owerinfo;
            TempData["OrderBy"] = desc;
            TempData["CurrentPage"] = pagecurrent;
            TempData["keys"] = objkeys;
            return View();
        }

        /// <summary>
        /// Ower_Add页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Ower_Add()
        {
           return View();
        }

        /// <summary>
        /// 添加业主信息（Ower_Add页面）
        /// </summary>
        public ActionResult Add_Ower()
        {

            OwerFactory owerfactory = new OwerFactory();
            //添加业主信息
            OwerM owerm = new OwerM();
            string owername = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
           
            bool isExist = owerfactory.IsExist_owername(owername);
            if (isExist) return ViewMethods.AlertBack("业主已存在,请重新确认", "-1");
            owerm.Name = owername;
            
            owerfactory.Infomation_ower = owerm;
            owerfactory.Save();
            return ViewMethods.AlertBack("添加业主成功！", "../../Ower/Ower");
        }

        /// <summary>
        /// 删除业主信息（Ower页面）
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete_Ower()
        {

            //获取业主编号（id）信息
            string uid = ViewMethods.GetForm(Request, "uid", CommonEnums.ValueEnum.vlPost).ToString();
            OwerM owerm = new OwerM();
            owerm.OWID = uid.ConvertToInt32();
            OwerFactory owerfactory = new OwerFactory();
            owerfactory.Infomation_ower = owerm;
            owerfactory.Del_Ower();
            return new JsonResult() { Data = PublicMethods.JSonHelper<string>.ObjectToJson(new { status = "0", msg = "删除成功" }), ContentType = "json" };
        }

        /// <summary>
        /// 编辑业主信息（Ower_Edit页面）
        /// </summary>
        public ActionResult Edit_Ower()
        {
            OwerFactory owerfactory = new OwerFactory();
            //获取用户编号（id）信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();
           
            IOwerB owerb = owerfactory.GetDataByID(id);
            OwerM owerm = (owerb == null ? null : owerb.Infomation_ower);
            //编辑管理组信息
            string owername = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            owerm.Name = owername;
            owerfactory.Infomation_ower = owerm;
            ViewBag.OwerInfo = owerm;
            bool isSuccess = owerfactory.Update();
            if (isSuccess)
                return ViewMethods.AlertBack("修改成功", "../../Ower/Ower");
            else
                return ViewMethods.AlertBack("修改失败", "-1");
        }

        /// <summary>
        /// Ower_Edit页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Ower_Edit()
        {

            //获取业主用户（id）数据信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();
            OwerFactory owerfactory = new OwerFactory();
            IOwerB lstOwer = owerfactory.GetDataByID(id);
            OwerM owerm = (lstOwer != null ? lstOwer.Infomation_ower : null);
            ViewBag.OwerInfo = owerm;
            return View();
        }

       
    }
}