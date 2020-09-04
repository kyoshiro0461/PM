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

            ProjectsFactory projectsfactory = new ProjectsFactory();
            List<IProjectsB> lstprojects = projectsfactory.GetPageData(ref count, start, pageSize, keys, order, orderway, belong);
            List<ProjectsM> projectsinfo = new List<ProjectsM>();
            if (lstprojects != null && lstprojects.Count > 0) lstprojects.ForEach(p => projectsinfo.Add(p.Infomation_projects));
            int totalpages = 0;
            if ((count % pageSize) > 0)
                totalpages = (int)Math.Ceiling((float)((count / pageSize) + 1));
            else
                totalpages = (int)Math.Ceiling((float)(count / pageSize));//算出分页的总数
            ViewBag.TotalPages = totalpages;
            ViewBag.Projects = projectsinfo;
            TempData["OrderBy"] = desc;
            TempData["CurrentPage"] = pagecurrent;
            TempData["keys"] = objkeys;
            TempData["belong"] = belong;
            return View();
        }

        /// <summary>
        /// Projects_Add页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Projects_Add()
        {
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


    }
}