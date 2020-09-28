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
    /// 客户页面控制器
    /// </summary>
    public class ClientsController : BaseController
    {
       
        public ActionResult Clients()
        {
            int pageSize = 12; //每页要显示的行数 
            string orderby = ViewMethods.GetForm(Request, "OrderBy", CommonEnums.ValueEnum.vlGet);
            string belong = ViewMethods.GetForm(Request, "BELONG");
            if (string.IsNullOrEmpty(orderby)) orderby = "CL_ID";
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

            ClientsFactory clientsfactory = new ClientsFactory();
            List<IClientsB> lstclients = clientsfactory.GetPageData(ref count, start, pageSize, keys, order, orderway, belong);
            List<ClientsM> clientsinfo = new List<ClientsM>();
            if (lstclients != null && lstclients.Count > 0) lstclients.ForEach(p => clientsinfo.Add(p.Infomation_clients));
            int totalpages = 0;
            if ((count % pageSize) > 0)
                totalpages = (int)Math.Ceiling((float)((count / pageSize) + 1));
            else
                totalpages = (int)Math.Ceiling((float)(count / pageSize));//算出分页的总数
            ViewBag.TotalPages = totalpages;
            ViewBag.ClientsInfo = clientsinfo;
            TempData["OrderBy"] = desc;
            TempData["CurrentPage"] = pagecurrent;
            TempData["keys"] = objkeys;
            TempData["belong"] = belong;
            return View();
        }


        /// <summary>
        /// Clients_Add页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Clients_Add()
        {
            string belong = ViewMethods.GetForm(Request, "BELONG");
            TempData["belong"] = belong;
            return View();
        }

        /// <summary>
        /// 添加客户信息（Clients_Add页面）
        /// </summary>
        public ActionResult Add_Clients()
        {
            string id = "";
            ClientsFactory clientsfactory = new ClientsFactory();
            //添加客户信息
            ClientsM clientsm = new ClientsM();
            string clientsname = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            string clientsbelong = ViewMethods.GetForm(Request, "belong", CommonEnums.ValueEnum.vlPost).ToString();
            string clientsperson = ViewMethods.GetForm(Request, "person", CommonEnums.ValueEnum.vlPost).ToString();
            string clientstel = ViewMethods.GetForm(Request, "tel", CommonEnums.ValueEnum.vlPost).ToString();
            string clientsaddress = ViewMethods.GetForm(Request, "address", CommonEnums.ValueEnum.vlPost).ToString();
            string clientscode = ViewMethods.GetForm(Request, "code", CommonEnums.ValueEnum.vlPost).ToString();
            string clientsbank = ViewMethods.GetForm(Request, "bank", CommonEnums.ValueEnum.vlPost).ToString();
            string clientsaccount = ViewMethods.GetForm(Request, "account", CommonEnums.ValueEnum.vlPost).ToString();
            bool isExist = clientsfactory.IsExist_clientsname(clientsname, id);
            if (isExist) return ViewMethods.AlertBack("客户已存在,请重新确认", "-1");
            if (clientsname == "") return ViewMethods.AlertBack("名称不能为空", "-1");
            clientsm.CLNAME = clientsname;
            clientsm.CLBELONG = clientsbelong.ConvertToInt32();
            clientsm.CLPERSON = clientsperson;
            clientsm.CLTEL = clientstel;
            clientsm.CLADDRESS = clientsaddress;
            clientsm.CLCODE = clientscode;
            clientsm.CLBANK = clientsbank;
            clientsm.CLACCOUNT = clientsaccount;

            clientsfactory.Infomation_clients = clientsm;
            clientsfactory.Save();
            return ViewMethods.AlertBack("添加客户成功！", "../../Clients/Clients?BELONG=" + clientsbelong);
        }

        /// <summary>
        /// 删除客户信息（Clients页面）
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete_Clients()
        {

            //获取客户编号（id）信息
            string uid = ViewMethods.GetForm(Request, "uid", CommonEnums.ValueEnum.vlPost).ToString();
            ClientsM clientsm = new ClientsM();
            clientsm.CLID = uid.ConvertToInt32();
            ClientsFactory clientsfactory = new ClientsFactory();
            clientsfactory.Infomation_clients = clientsm;
            clientsfactory.Del_Clients();
            return new JsonResult() { Data = PublicMethods.JSonHelper<string>.ObjectToJson(new { status = "0", msg = "删除成功" }), ContentType = "json" };
        }

        /// <summary>
        /// 编辑客户信息（Clients_Edit页面）
        /// </summary>
        public ActionResult Edit_Clients()
        {
            ClientsFactory clientsfactory = new ClientsFactory();
            //获取客户编号（id）信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();

            IClientsB clientsb = clientsfactory.GetDataByID(id);
            ClientsM clientsm = (clientsb == null ? null : clientsb.Infomation_clients);
            //编辑客户信息
            string clientsname = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            string clientsbelong = ViewMethods.GetForm(Request, "belong", CommonEnums.ValueEnum.vlPost).ToString();
            string clientsperson = ViewMethods.GetForm(Request, "person", CommonEnums.ValueEnum.vlPost).ToString();
            string clientstel = ViewMethods.GetForm(Request, "tel", CommonEnums.ValueEnum.vlPost).ToString();
            string clientsaddress = ViewMethods.GetForm(Request, "address", CommonEnums.ValueEnum.vlPost).ToString();
            string clientscode = ViewMethods.GetForm(Request, "code", CommonEnums.ValueEnum.vlPost).ToString();
            string clientsbank = ViewMethods.GetForm(Request, "bank", CommonEnums.ValueEnum.vlPost).ToString();
            string clientsaccount = ViewMethods.GetForm(Request, "account", CommonEnums.ValueEnum.vlPost).ToString();
            bool isExist = clientsfactory.IsExist_clientsname(clientsname, id);
            if (isExist) return ViewMethods.AlertBack("客户已存在,请重新确认", "-1");
            if (clientsname == "") return ViewMethods.AlertBack("名称不能为空", "-1");
            clientsm.CLNAME = clientsname;
            clientsm.CLBELONG = clientsbelong.ConvertToInt32();
            clientsm.CLPERSON = clientsperson;
            clientsm.CLTEL = clientstel;
            clientsm.CLADDRESS = clientsaddress;
            clientsm.CLCODE = clientscode;
            clientsm.CLBANK = clientsbank;
            clientsm.CLACCOUNT = clientsaccount;
            clientsfactory.Infomation_clients = clientsm;
            ViewBag.ClientsInfo = clientsm;
            bool isSuccess = clientsfactory.Update();
            if (isSuccess)
                return ViewMethods.AlertBack("修改成功", "../../Clients/Clients?BELONG=" + clientsbelong);
            else
                return ViewMethods.AlertBack("修改失败", "-1");
        }

        /// <summary>
        /// Clients_Edit页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Clients_Edit()
        {

            //获取客户用户（id）数据信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();
            ClientsFactory clientsfactory = new ClientsFactory();
            IClientsB lstClients = clientsfactory.GetDataByID(id);
            ClientsM clientsm = (lstClients != null ? lstClients.Infomation_clients : null);
            ViewBag.ClientsInfo = clientsm;
            return View();
        }

        /// <summary>
        /// Clients_List页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Clients_List()
        {

            //获取客户用户（id）数据信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();
            ClientsFactory clientsfactory = new ClientsFactory();
            IClientsB lstClients = clientsfactory.GetDataByID(id);
            ClientsM clientsm = (lstClients != null ? lstClients.Infomation_clients : null);
            ViewBag.ClientsInfo = clientsm;
            return View();
        }
    }
}