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
    /// 项目页面控制器
    /// </summary>
    public class ProjectsController : BaseController
    {
        // GET: Ower
        public ActionResult Projects()
        {
            int pageSize = 12; //每页要显示的行数 
            string belong = ViewMethods.GetForm(Request, "BELONG");
            string ptid = ViewMethods.GetForm(Request, "PTID");
            string orderby = ViewMethods.GetForm(Request, "OrderBy", CommonEnums.ValueEnum.vlGet);
            if (string.IsNullOrEmpty(orderby)) orderby = "PR_ID";
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
            
            //调取项目组信息
            ProjectsTeamFactory projectsTeamFactory = new ProjectsTeamFactory();
            List<IProjectsTeamB> lstProjectsTeam = projectsTeamFactory.GetDataProjectsTeam();
            List<ProjectsTeamM> ProjectsTeamInfo = new List<ProjectsTeamM>();
            lstProjectsTeam.ForEach(p => ProjectsTeamInfo.Add(p.Infomation_projectsteam));
            

            //调取项目信息
            ProjectsFactory projectsfactory = new ProjectsFactory();
            List<IProjectsB> lstprojects = projectsfactory.GetPageData(ref count, start, pageSize, keys, order, orderway, belong, ptid);
            List<ProjectsM> projectsinfo = new List<ProjectsM>();
            if (lstprojects != null && lstprojects.Count > 0) lstprojects.ForEach(p => projectsinfo.Add(p.Infomation_projects));

            //分页数据
            int totalpages = 0;
            if ((count % pageSize) > 0)
                totalpages = (int)Math.Ceiling((float)((count / pageSize) + 1));
            else
                totalpages = (int)Math.Ceiling((float)(count / pageSize));//算出分页的总数

            //前端页面数据推送
            ViewBag.TotalPages = totalpages;
            ViewBag.Projects = projectsinfo;
            TempData["OrderBy"] = desc;
            TempData["CurrentPage"] = pagecurrent;
            TempData["keys"] = objkeys;
            TempData["belong"] = belong;
            ViewBag.ProjectsTeamInfo = ProjectsTeamInfo;
            return View();
        }

        /// <summary>
        /// Projects_Add页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Projects_Add()
        {
            //获取往来客户信息
            ClientsFactory clientsFactory = new ClientsFactory();
            List<IClientsB> lstClients = clientsFactory.GetDataClients();
            List<ClientsM> ClientsInfo = new List<ClientsM>();
            lstClients.ForEach(p => ClientsInfo.Add(p.Infomation_clients));
            TempData["ClientsInfo"] = ClientsInfo;

            return View();
        }

        /// <summary>
        /// 添加项目信息（Projects_Add页面）
        /// </summary>
        public ActionResult Add_Projects()
        {

            ProjectsFactory projectsfactory = new ProjectsFactory();
            //添加业主信息
            ProjectsM projectsm = new ProjectsM();
            string projectsname = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            string prbelong = ViewMethods.GetForm(Request, "belong", CommonEnums.ValueEnum.vlPost).ToString();
            bool isExist = projectsfactory.IsExist_projectsname(projectsname);
            if (isExist) return ViewMethods.AlertBack("项目已存在,请重新确认", "-1");
            projectsm.PRName = projectsname;
            projectsm.PRBelong = prbelong;
            projectsfactory.Infomation_projects = projectsm;
            projectsfactory.Save();
            return ViewMethods.AlertBack("添加项目成功！", "../../Projects/Projects");
        }

        /// <summary>
        /// 删除项目信息（Projects页面）
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete_Projects()
        {

            //获取项目编号（id）信息
            string uid = ViewMethods.GetForm(Request, "uid", CommonEnums.ValueEnum.vlPost).ToString();
            ProjectsM projectsm = new ProjectsM();
            projectsm.PRID = uid.ConvertToInt32();
            ProjectsFactory projectsfactory = new ProjectsFactory();
            projectsfactory.Infomation_projects = projectsm;
            projectsfactory.Del_Projects();
            return new JsonResult() { Data = PublicMethods.JSonHelper<string>.ObjectToJson(new { status = "0", msg = "删除成功" }), ContentType = "json" };
        }

        /// <summary>
        /// 编辑项目信息（Projects_Edit页面）
        /// </summary>
        public ActionResult Edit_Projects()
        {
            ProjectsFactory projectsfactory = new ProjectsFactory();
            //获取项目编号（id）信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();

            IProjectsB projectsb = projectsfactory.GetDataByID(id);
            ProjectsM projectsm = (projectsb == null ? null : projectsb.Infomation_projects);
            //编辑项目信息
            string projectsname = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            string projectsbelong = ViewMethods.GetForm(Request, "belong", CommonEnums.ValueEnum.vlPost).ToString();
            projectsm.PRName = projectsname;
            projectsm.PRBelong = projectsbelong;
            projectsfactory.Infomation_projects = projectsm;
            ViewBag.ProjectsInfo = projectsm;
            bool isSuccess = projectsfactory.Update();
            if (isSuccess)
                return ViewMethods.AlertBack("修改成功", "../../Projects/Projects");
            else
                return ViewMethods.AlertBack("修改失败", "-1");
        }

        /// <summary>
        /// Projects_Edit页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Projects_Edit()
        {

            //获取项目编号（id）数据信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();
            ProjectsFactory projectsfactory = new ProjectsFactory();
            IProjectsB lstProjects = projectsfactory.GetDataByID(id);
            ProjectsM projectsm = (lstProjects != null ? lstProjects.Infomation_projects : null);
            ViewBag.ProjectsInfo = projectsm;
            return View();
        }

        /// <summary>
        /// 根据隶属编号获取隶属分类
        /// </summary>
        /// <returns>隶属JSon对象</returns>
        public ActionResult GetBelong()
        {
            int belong = ViewMethods.GetForm(Request, "belong", CommonEnums.ValueEnum.vlPost).ConvertToInt32();
            List<ClientsM> ClientsInfo = (TempData["ClientsInfo"] as List<ClientsM>);
            List<ClientsM> lstClientsM = null;
            lstClientsM = new List<ClientsM>();
            if (ClientsInfo != null && belong != -1) lstClientsM = ClientsInfo.Where(p => p.CLBELONG == belong).ToList();

            JsonResult result = new JsonResult();
            result.Data = PublicMethods.JSonHelper<string>.ObjectToJson(lstClientsM);
            result.ContentType = "json";

            TempData["ClientsInfo"] = ClientsInfo;

            return result;
        }

        /// <summary>
        /// Projects_List页面
        /// </summary>
        /// <returns>页面</returns>
        public ActionResult Projects_List()
        {
            //获取项目编号（id）数据信息
            string id = ViewMethods.GetForm(Request, "PRID", CommonEnums.ValueEnum.vlGet).ToString();

            //根据项目编号（id）获取项目信息
            ProjectsFactory projectsfactory = new ProjectsFactory();
            IProjectsB lstProjects = projectsfactory.GetDataByID(id);
            ProjectsM projectsm = (lstProjects != null ? lstProjects.Infomation_projects : null);
            ViewBag.ProjectsInfo = projectsm;

            //获取往来客户信息
            ClientsFactory clientsFactory = new ClientsFactory();
            List<IClientsB> lstClients = clientsFactory.GetDataClients();
            List<ClientsM> clientsm = new List<ClientsM>();
            if (lstClients != null && lstClients.Count > 0) lstClients.ForEach(p => clientsm.Add(p.Infomation_clients));
            ViewBag.ClientsInfo = clientsm;

            //获取收付款信息
            FinanceFactory financeFactory = new FinanceFactory();
            List<IFinanceB> lstFinance = financeFactory.GetDataFinance();
            List<FinanceM> financem = new List<FinanceM>();
            if (lstFinance != null && lstFinance.Count > 0) lstFinance.ForEach(p => financem.Add(p.Infomation_finance));
            ViewBag.FinanceInfo = financem;

            //获取工程量信息
            QuantityFactory quantityFactory = new QuantityFactory();
            List<IQuantityB> lstQuantity = quantityFactory.GetDataQuantity();
            List<QuantityM> quantity = new List<QuantityM>();
            if (lstQuantity != null && lstQuantity.Count > 0) lstQuantity.ForEach(p => quantity.Add(p.Infomation_Quantity));
            ViewBag.QuantityInfo = quantity;

            //获取合同信息
            ContractFactory contractFactory = new ContractFactory();
            List<IContractB> lstContract = contractFactory.GetDataContract();
            List<ContractM> contracts = new List<ContractM>();
            if (lstContract != null && lstContract.Count > 0) lstContract.ForEach(p => contracts.Add(p.Infomation_contract));
            ViewBag.ContractInfo = contracts;

            return View();
        }

        

        
    }
}