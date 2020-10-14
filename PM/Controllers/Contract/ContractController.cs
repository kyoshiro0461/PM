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
    /// 合同页面控制器
    /// </summary>
    public class ContractController : BaseController
    {
        // GET: Ower
        public ActionResult Contract()
        {
            string  prid = ViewMethods.GetForm(Request, "PRID");
           
            int pageSize = 12; //每页要显示的行数 
            string belong = ViewMethods.GetForm(Request, "BELONG");
            string orderby = ViewMethods.GetForm(Request, "OrderBy", CommonEnums.ValueEnum.vlGet);
            if (string.IsNullOrEmpty(orderby)) orderby = "CT_ID";
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

            ContractFactory contractfactory = new ContractFactory();
            List<IContractB> lstcontract = contractfactory.GetPageData(ref count, start, pageSize, keys, order, orderway, belong, prid);
            List<ContractM> contractinfo = new List<ContractM>();
            if (lstcontract != null && lstcontract.Count > 0) lstcontract.ForEach(p => contractinfo.Add(p.Infomation_contract));
            int totalpages = 0;
            if ((count % pageSize) > 0)
                totalpages = (int)Math.Ceiling((float)((count / pageSize) + 1));
            else
                totalpages = (int)Math.Ceiling((float)(count / pageSize));//算出分页的总数

            ViewBag.TotalPages = totalpages;
            ViewBag.Contract = contractinfo;
            TempData["OrderBy"] = desc;
            TempData["CurrentPage"] = pagecurrent;
            TempData["keys"] = objkeys;
            TempData["belong"] = belong;
            if(prid != null || prid != "")
            {
                TempData["prid"] = prid;
            }
            return View();
        }

        /// <summary>
        /// Contract_Add页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Contract_Add()
        {
            string prid = ViewMethods.GetForm(Request, "PRID");
            TempData["prid"] = prid;
            return View();
        }

        /// <summary>
        /// 添加合同信息（Contract_Add页面）
        /// </summary>
        public ActionResult Add_Contract()
        {
            string  prid = ViewMethods.GetForm(Request, "PRID");
            ContractFactory contractfactory = new ContractFactory();
            //添加业主信息
            ContractM contractm = new ContractM();
            string contractname = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            string ctbelong = ViewMethods.GetForm(Request, "belong", CommonEnums.ValueEnum.vlPost).ToString();
            string ctno = ViewMethods.GetForm(Request, "ctno", CommonEnums.ValueEnum.vlPost).ToString();
            decimal ctmoney = ViewMethods.GetForm(Request, "money", CommonEnums.ValueEnum.vlPost).ConvertToDecimal();

            bool isExist = contractfactory.IsExist_contractname(contractname);
            if (isExist) return ViewMethods.AlertBack("合同已存在,请重新确认", "-1");
            contractm.CTName = contractname;
            contractm.CTBelong = ctbelong;
            contractm.CTNo = ctno;
            contractm.CTMoney = ctmoney;
            contractm.CTDate = DateTime.Now;
            contractm.CTPrid = prid.ConvertToInt32();
            contractfactory.Infomation_contract = contractm;
            contractfactory.Save();
            return ViewMethods.AlertBack("添加合同成功！", "../../Contract/Contract?PRID="+prid);
        }

        /// <summary>
        /// 删除业主信息（Ower页面）
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete_Contract()
        {

            //获取业主编号（id）信息
            string uid = ViewMethods.GetForm(Request, "uid", CommonEnums.ValueEnum.vlPost).ToString();
            ContractM contractm = new ContractM();
            contractm.CTID = uid.ConvertToInt32();
            ContractFactory contractfactory = new ContractFactory();
            contractfactory.Infomation_contract = contractm;
            contractfactory.Del_Contract();
            return new JsonResult() { Data = PublicMethods.JSonHelper<string>.ObjectToJson(new { status = "0", msg = "删除成功" }), ContentType = "json" };
        }

        /// <summary>
        /// 编辑业主信息（Ower_Edit页面）
        /// </summary>
        public ActionResult Edit_Contract()
        {
            ContractFactory contractfactory = new ContractFactory();
            //获取业主编号（id）信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();

            IContractB contractb = contractfactory.GetDataByID(id);
            ContractM contractm = (contractb == null ? null : contractb.Infomation_contract);
            //编辑业主信息
            string contractname = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            string contractbelong = ViewMethods.GetForm(Request, "belong", CommonEnums.ValueEnum.vlPost).ToString();
            contractm.CTName = contractname;
            contractm.CTBelong = contractbelong;
            contractfactory.Infomation_contract = contractm;
            ViewBag.ContractInfo = contractm;
            bool isSuccess = contractfactory.Update();
            if (isSuccess)
                return ViewMethods.AlertBack("修改成功", "../../Contract/Contract");
            else
                return ViewMethods.AlertBack("修改失败", "-1");
        }

        /// <summary>
        /// Ower_Edit页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Contract_Edit()
        {

            //获取业主用户（id）数据信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();
            ContractFactory contractfactory = new ContractFactory();
            IContractB lstContract = contractfactory.GetDataByID(id);
            ContractM contractm = (lstContract != null ? lstContract.Infomation_contract : null);
            ViewBag.ContractInfo = contractm;
            return View();
        }


    }
}