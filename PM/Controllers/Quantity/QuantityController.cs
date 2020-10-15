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
    /// 工程量页面控制器
    /// </summary>
    public class QuantityController : BaseController
    {
        // GET: Ower
        public ActionResult Quantity()
        {
            string prid = ViewMethods.GetForm(Request, "PRID");

            ProjectsFactory projectsfactory = new ProjectsFactory();
            List<IProjectsB> lstprojects = projectsfactory.GetDataProjects();
            List<ProjectsM> projectsm = new List<ProjectsM>();
            if (lstprojects != null && lstprojects.Count > 0) lstprojects.ForEach(p => projectsm.Add(p.Infomation_projects));
            ViewBag.Projects = projectsm;

            int pageSize = 12; //每页要显示的行数 
            //string collectpay = ViewMethods.GetForm(Request, "Collectpay");
            string orderby = ViewMethods.GetForm(Request, "OrderBy", CommonEnums.ValueEnum.vlGet);
            if (string.IsNullOrEmpty(orderby)) orderby = "QT_ID";
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

            QuantityFactory quantityfactory = new QuantityFactory();
            List<IQuantityB> lstquantity = quantityfactory.GetPageData(ref count, start, pageSize, keys, order, orderway);
            List<QuantityM> quantityinfo = new List<QuantityM>();
            if (lstquantity != null && lstquantity.Count > 0) lstquantity.ForEach(p => quantityinfo.Add(p.Infomation_Quantity));
            int totalpages = 0;
            if ((count % pageSize) > 0)
                totalpages = (int)Math.Ceiling((float)((count / pageSize) + 1));
            else
                totalpages = (int)Math.Ceiling((float)(count / pageSize));//算出分页的总数
            ViewBag.TotalPages = totalpages;
            ViewBag.Quantity = quantityinfo;
           
            TempData["OrderBy"] = desc;
            TempData["CurrentPage"] = pagecurrent;
            TempData["keys"] = objkeys;
            //TempData["collectpay"] = collectpay;
            return View();
        }

        /// <summary>
        /// Quantity_Add页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Quantity_Add()
        {
            return View();
        }

        /// <summary>
        /// 添加工程量信息（Quantity_Add页面）
        /// </summary>
        public ActionResult Add_Quantity()
        {

            QuantityFactory quantityfactory = new QuantityFactory();
            //添加业主信息
            QuantityM quantitym = new QuantityM();
            string content = ViewMethods.GetForm(Request, "content", CommonEnums.ValueEnum.vlPost).ToString();
            string measurement = ViewMethods.GetForm(Request, "measurement", CommonEnums.ValueEnum.vlPost).ToString();
            decimal quantity = ViewMethods.GetForm(Request, "quantity", CommonEnums.ValueEnum.vlPost).ConvertToDecimal();
            decimal price = ViewMethods.GetForm(Request, "price", CommonEnums.ValueEnum.vlPost).ConvertToDecimal();
            decimal money = ViewMethods.GetForm(Request, "money", CommonEnums.ValueEnum.vlPost).ConvertToDecimal();
            quantitym.QTCONTENT = content;
            quantitym.QTMEASUREMENT = measurement;
            quantitym.QTQUANTITY = quantity;
            quantitym.QTPRICE = price;
            quantitym.QTMONEY = money;
            quantityfactory.Infomation_quantity = quantitym;
            quantityfactory.Save();
            return ViewMethods.AlertBack("添加工程量成功！", "../../Quantity/Quantity");
        }

        /// <summary>
        /// 删除工程量信息（Quantity页面）
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete_Quantity()
        {

            //获取工程量编号（id）信息
            string uid = ViewMethods.GetForm(Request, "uid", CommonEnums.ValueEnum.vlPost).ToString();
            QuantityM quantitym = new QuantityM();
            quantitym.QTID = uid.ConvertToInt32();
            QuantityFactory quantityfactory = new QuantityFactory();
            quantityfactory.Infomation_quantity = quantitym;
            quantityfactory.Del_Quantity();
            return new JsonResult() { Data = PublicMethods.JSonHelper<string>.ObjectToJson(new { status = "0", msg = "删除成功" }), ContentType = "json" };
        }

        /// <summary>
        /// 编辑工程量信息（Quantity_Edit页面）
        /// </summary>
        public ActionResult Edit_Quantity()
        {
            QuantityFactory quantityfactory = new QuantityFactory();
            //获取工程量编号（id）信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();

            IQuantityB quantityb = quantityfactory.GetDataByID(id);
            QuantityM quantitym = (quantityb == null ? null : quantityb.Infomation_Quantity);
            //编辑工程量信息
            string quantityname = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            string quantitybelong = ViewMethods.GetForm(Request, "belong", CommonEnums.ValueEnum.vlPost).ToString();
            //quantitym.SFName = quantityname;
            //quantitym.SFBelong = quantitybelong;
            quantityfactory.Infomation_quantity = quantitym;
            ViewBag.QuantityInfo = quantitym;
            bool isSuccess = quantityfactory.Update();
            if (isSuccess)
                return ViewMethods.AlertBack("修改成功", "../../Quantity/Quantity");
            else
                return ViewMethods.AlertBack("修改失败", "-1");
        }

        /// <summary>
        /// Quantity_Edit页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Quantity_Edit()
        {

            //获取工程量编号（id）数据信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();
            QuantityFactory quantityfactory = new QuantityFactory();
            IQuantityB lstQuantity = quantityfactory.GetDataByID(id);
            QuantityM quantitym = (lstQuantity != null ? lstQuantity.Infomation_Quantity : null);
            ViewBag.QuantityInfo = quantitym;
            return View();
        }

        /// <summary>
        /// Quantity_List页面行为
        /// </summary>
        /// <return>视图</return>
        public ActionResult Quantity_List()
        {
            //获取项目信息
            ProjectsFactory projectsfactory = new ProjectsFactory();
            List<IProjectsB> lstprojects = projectsfactory.GetDataProjects();
            List<ProjectsM> projectsm = new List<ProjectsM>();
            if (lstprojects != null && lstprojects.Count > 0) lstprojects.ForEach(p => projectsm.Add(p.Infomation_projects));
            ViewBag.Projects = projectsm;
            
            //获取工程量单ID数据信息
            string sfid = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();
            QuantityFactory quantityFactory = new QuantityFactory();
            IQuantityB lstQuantity = quantityFactory.GetDataByID(sfid);
            QuantityM quantitym = (lstQuantity != null ? lstQuantity.Infomation_Quantity : null);
            ViewBag.QuantityInfo = quantitym;
            return View();
        }
    }
}