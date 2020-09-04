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
    /// 收付款页面控制器
    /// </summary>
    public class FinanceController : BaseController
    {
        // GET: Ower
        public ActionResult Finance()
        {
            int pageSize = 12; //每页要显示的行数 
            string belong = ViewMethods.GetForm(Request, "BELONG");
            string orderby = ViewMethods.GetForm(Request, "OrderBy", CommonEnums.ValueEnum.vlGet);
            if (string.IsNullOrEmpty(orderby)) orderby = "SF_ID";
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

            FinanceFactory financefactory = new FinanceFactory();
            List<IFinanceB> lstfinance = financefactory.GetPageData(ref count, start, pageSize, keys, order, orderway, belong);
            List<FinanceM> financeinfo = new List<FinanceM>();
            if (lstfinance != null && lstfinance.Count > 0) lstfinance.ForEach(p => financeinfo.Add(p.Infomation_finance));
            int totalpages = 0;
            if ((count % pageSize) > 0)
                totalpages = (int)Math.Ceiling((float)((count / pageSize) + 1));
            else
                totalpages = (int)Math.Ceiling((float)(count / pageSize));//算出分页的总数
            ViewBag.TotalPages = totalpages;
            ViewBag.Finance = financeinfo;
            TempData["OrderBy"] = desc;
            TempData["CurrentPage"] = pagecurrent;
            TempData["keys"] = objkeys;
            TempData["belong"] = belong;
            return View();
        }

        /// <summary>
        /// Finance_Add页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Finance_Add()
        {
            return View();
        }

        /// <summary>
        /// 添加收付款信息（Finance_Add页面）
        /// </summary>
        public ActionResult Add_Finance()
        {

            FinanceFactory financefactory = new FinanceFactory();
            //添加业主信息
            FinanceM financem = new FinanceM();
            string financename = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            string prbelong = ViewMethods.GetForm(Request, "belong", CommonEnums.ValueEnum.vlPost).ToString();
            bool isExist = financefactory.IsExist_financename(financename);
            if (isExist) return ViewMethods.AlertBack("收付款已存在,请重新确认", "-1");
            financem.SFName = financename;
            financem.SFBelong = prbelong;
            financefactory.Infomation_finance = financem;
            financefactory.Save();
            return ViewMethods.AlertBack("添加收付款成功！", "../../Finance/Finance");
        }

        /// <summary>
        /// 删除收付款信息（Finance页面）
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete_Finance()
        {

            //获取收付款编号（id）信息
            string uid = ViewMethods.GetForm(Request, "uid", CommonEnums.ValueEnum.vlPost).ToString();
            FinanceM financem = new FinanceM();
            financem.SFID = uid.ConvertToInt32();
            FinanceFactory financefactory = new FinanceFactory();
            financefactory.Infomation_finance = financem;
            financefactory.Del_Finance();
            return new JsonResult() { Data = PublicMethods.JSonHelper<string>.ObjectToJson(new { status = "0", msg = "删除成功" }), ContentType = "json" };
        }

        /// <summary>
        /// 编辑收付款信息（Finance_Edit页面）
        /// </summary>
        public ActionResult Edit_Finance()
        {
            FinanceFactory financefactory = new FinanceFactory();
            //获取收付款编号（id）信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();

            IFinanceB financeb = financefactory.GetDataByID(id);
            FinanceM financem = (financeb == null ? null : financeb.Infomation_finance);
            //编辑收付款信息
            string financename = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            string financebelong = ViewMethods.GetForm(Request, "belong", CommonEnums.ValueEnum.vlPost).ToString();
            financem.SFName = financename;
            financem.SFBelong = financebelong;
            financefactory.Infomation_finance = financem;
            ViewBag.FinanceInfo = financem;
            bool isSuccess = financefactory.Update();
            if (isSuccess)
                return ViewMethods.AlertBack("修改成功", "../../Finance/Finance");
            else
                return ViewMethods.AlertBack("修改失败", "-1");
        }

        /// <summary>
        /// Finance_Edit页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Finance_Edit()
        {

            //获取收付款编号（id）数据信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();
            FinanceFactory financefactory = new FinanceFactory();
            IFinanceB lstFinance = financefactory.GetDataByID(id);
            FinanceM financem = (lstFinance != null ? lstFinance.Infomation_finance : null);
            ViewBag.FinanceInfo = financem;
            return View();
        }


    }
}