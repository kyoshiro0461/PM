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
    /// 供应商页面控制器
    /// </summary>
    public class SuppliersController : BaseController
    {
        // GET: Suppliers
        public ActionResult Suppliers()
        {
            int pageSize = 12; //每页要显示的行数 
            string orderby = ViewMethods.GetForm(Request, "OrderBy", CommonEnums.ValueEnum.vlGet);
            if (string.IsNullOrEmpty(orderby)) orderby = "SP_ID";
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

            SuppliersFactory suppliersfactory = new SuppliersFactory();
            List<ISuppliersB> lstsuppliers = suppliersfactory.GetPageData(ref count, start, pageSize, keys, order, orderway);
            List<SuppliersM> suppliersinfo = new List<SuppliersM>();
            if (lstsuppliers != null && lstsuppliers.Count > 0) lstsuppliers.ForEach(p => suppliersinfo.Add(p.Infomation_suppliers));
            int totalpages = 0;
            if ((count % pageSize) > 0)
                totalpages = (int)Math.Ceiling((float)((count / pageSize) + 1));
            else
                totalpages = (int)Math.Ceiling((float)(count / pageSize));//算出分页的总数
            ViewBag.TotalPages = totalpages;
            ViewBag.SuppliersInfo = suppliersinfo;
            TempData["OrderBy"] = desc;
            TempData["CurrentPage"] = pagecurrent;
            TempData["keys"] = objkeys;
            return View();
        }

        /// <summary>
        /// Suppliers_Add页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Suppliers_Add()
        {
            return View();
        }

        /// <summary>
        /// 添加供应商信息（Suppliers_Add页面）
        /// </summary>
        public ActionResult Add_Suppliers()
        {

            SuppliersFactory suppliersfactory = new SuppliersFactory();
            //添加供应商信息
            SuppliersM suppliersm = new SuppliersM();
            string suppliersname = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();

            bool isExist = suppliersfactory.IsExist_suppliersname(suppliersname);
            if (isExist) return ViewMethods.AlertBack("供应商已存在,请重新确认", "-1");
            suppliersm.Name = suppliersname;

            suppliersfactory.Infomation_suppliers = suppliersm;
            suppliersfactory.Save();
            return ViewMethods.AlertBack("添加供应商成功！", "../../Suppliers/Suppliers");
        }

        /// <summary>
        /// 删除供应商信息（Suppliers页面）
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete_Suppliers()
        {

            //获取供应商编号（id）信息
            string uid = ViewMethods.GetForm(Request, "uid", CommonEnums.ValueEnum.vlPost).ToString();
            SuppliersM suppliersm = new SuppliersM();
            suppliersm.SPID = uid.ConvertToInt32();
            SuppliersFactory suppliersfactory = new SuppliersFactory();
            suppliersfactory.Infomation_suppliers = suppliersm;
            suppliersfactory.Del_Suppliers();
            return new JsonResult() { Data = PublicMethods.JSonHelper<string>.ObjectToJson(new { status = "0", msg = "删除成功" }), ContentType = "json" };
        }

        /// <summary>
        /// 编辑供应商信息（Suppliers_Edit页面）
        /// </summary>
        public ActionResult Edit_Suppliers()
        {
            SuppliersFactory suppliersfactory = new SuppliersFactory();
            //获取供应商编号（id）信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();

            ISuppliersB suppliersb = suppliersfactory.GetDataByID(id);
            SuppliersM suppliersm = (suppliersb == null ? null : suppliersb.Infomation_suppliers);
            //编辑供应商信息
            string suppliersname = ViewMethods.GetForm(Request, "name", CommonEnums.ValueEnum.vlPost).ToString();
            suppliersm.Name = suppliersname;
            suppliersfactory.Infomation_suppliers = suppliersm;
            ViewBag.SuppliersInfo = suppliersm;
            bool isSuccess = suppliersfactory.Update();
            if (isSuccess)
                return ViewMethods.AlertBack("修改成功", "../../Suppliers/Suppliers");
            else
                return ViewMethods.AlertBack("修改失败", "-1");
        }

        /// <summary>
        /// Suppliers_Edit页面行为
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Suppliers_Edit()
        {

            //获取供应商用户（id）数据信息
            string id = ViewMethods.GetForm(Request, "ID", CommonEnums.ValueEnum.vlGet).ToString();
            SuppliersFactory suppliersfactory = new SuppliersFactory();
            ISuppliersB lstSuppliers = suppliersfactory.GetDataByID(id);
            SuppliersM suppliersm = (lstSuppliers != null ? lstSuppliers.Infomation_suppliers : null);
            ViewBag.SuppliersInfo = suppliersm;
            return View();
        }


    }
}