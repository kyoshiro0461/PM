using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMModel;
using PMBLL.Instance;
using PMDAL.Instance;
using PublicMethods;

namespace PMBLL.Instance
{
    /// <summary>
    /// 供应商信息类（业务逻辑层）
    /// </summary>
    public class SuppliersB : ISuppliersB
    {
        #region 常量
        const string GROUPNAME = "SuppliersGroup";                           //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                       //Section名称
        #endregion
        #region 变量
        private ISuppliersD _suppliersd;                                         //供应商信息类（数据链路层）
        private string _methodnm_GetDefaultSuppliers;                       //GetDefaultSuppliers方法名
        private string _methodnm_GetPageData;                          //GetPageData
        private string _methodnm_IsExist_suppliersname;                    //IsExist_suppliersname方法名
        private IConnectionB _connectionb;                            //链接类（业务逻辑层）
        private SuppliersM _suppliersm;                                         //供应商信息类（模型层）
        private string _methodnm_GetDataByID;                         //GetDataByID方法名
        public SuppliersM Infomation_suppliers
        {
            get { return this._suppliersm; }
            set { this._suppliersm = value; this._suppliersd.Infomation_suppliers = this._suppliersm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectionb">链接类</param>
        public SuppliersB(IConnectionB connectionb)
        {
            this._connectionb = connectionb;
            InitObject();//初始化对象
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">供应商信息类（模型层）</param>
        /// <param name="connectionb">链接类</param>
        public SuppliersB(SuppliersM info, IConnectionB connectionb)
            : this(connectionb)
        {
            this.Infomation_suppliers = info;
        }
        #endregion
        #region 方法
        /// <summary>
        /// 初始化对象
        /// </summary>
        void InitObject()
        {
            string strNameSpace = "", strInstance = "";
            ReadConfigFile(ref strNameSpace, ref strInstance);
            InstanceObject(strNameSpace, strInstance);//实例化对象
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="strNameSpace">返回 命名空间字符串</param>
        /// <param name="strInstance">返回 实例字符串</param>
        void ReadConfigFile(ref string strNameSpace, ref string strInstance)
        {
            string configPath = Common.CommonMethods.GetConfigPath();
            //读取配置文件的信息
            Sections.SuppliersSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.SuppliersSection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
                this._methodnm_GetDefaultSuppliers = section.GetDataSuppliersMethod;   //GetDefaultSuppliers方法名
                this._methodnm_GetPageData = section.GetPageDataMethod;
                this._methodnm_IsExist_suppliersname = section.IsExist_suppliersnameMethod;//IsExist_suppliersname方法名
                this._methodnm_GetDataByID = section.GetDataByIDMethod;     //GetDataByID方法名
            }
        }
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="strInstance">实例名</param>
        void InstanceObject(string strNameSpace, string strInstance)
        {
            this._suppliersd = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionb.ConnectionD }) as SuppliersD;
        }
        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="lstSuppliers">供应商信息类（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        List<ISuppliersB> ConvertToSuppliersB(List<SuppliersM> lstSuppliers)
        {
            List<ISuppliersB> result = null;
            if (lstSuppliers != null && lstSuppliers.Count > 0)
            {
                result = new List<ISuppliersB>();
                lstSuppliers.ForEach(p => result.Add(new SuppliersB(this._connectionb) { Infomation_suppliers = p }));
            }
            return result;
        }
        /// <summary>
        /// 获取供应商集合数据
        /// </summary>
        /// <param >获取Suppliers表集合数据</param>
        /// <returns>分类信息（业务逻辑层）集合</returns>
        public List<ISuppliersB> GetDataSuppliers()
        {
            //通过反射调用数据链路层的分类信息集合
            List<SuppliersM> lstSuppliers = Methods.ReflexInvokeMethod(this._suppliersd, this._methodnm_GetDefaultSuppliers, new Type[] { typeof(IConnectionD) }, new object[] { this._connectionb.ConnectionD }) as List<SuppliersM>;
            if (lstSuppliers != null && lstSuppliers.Count > 0) lstSuppliers = lstSuppliers.Where(p => true).ToList();
            return ConvertToSuppliersB(lstSuppliers);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="count">总共数据</param>
        /// <param name="start">起始数据</param>
        /// <param name="size">显示笔数</param>
        /// <param name="orderway">排序方式</param>
        /// <param name="key">搜索条件</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public List<ISuppliersB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway)
        {
            object[] args = new object[] { count, start, size, key, order, orderway, this._connectionb.ConnectionD };
            List<SuppliersM> lstsuppliers = Methods.ReflexInvokeMethod(this._suppliersd, this._methodnm_GetPageData, new Type[] { typeof(long).MakeByRefType(), typeof(long), typeof(int), typeof(string), typeof(string), typeof(OrderType), typeof(IConnectionD) }, args) as List<SuppliersM>;
            count = args[0].ConvertToInt64();
            return ConvertToSuppliersB(lstsuppliers);
        }
        /// <summary>
        /// 判断供应商是否存在
        /// </summary>
        /// <param name="suppliersname">供应商名</param>
        /// <returns>供应商信息类</returns>
        public SuppliersM IsExist_suppliersname(string suppliersname)
        {
            //通过反射调用数据链路层的用户类IsExist_username判断供应商是否存在
            return Methods.ReflexInvokeMethod(this._suppliersd, this._methodnm_IsExist_suppliersname, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { suppliersname, this._connectionb.ConnectionD }) as SuppliersM;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            return this._suppliersd.Save();//存档
        }

        /// <summary>
        /// 删除供应商信息(Suppliers页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Del_Suppliers()
        {
            return this._suppliersd.Del_Suppliers();
        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>数据</returns>
        public ISuppliersB GetDataByID(string id)
        {
            SuppliersM result = Methods.ReflexInvokeMethod(this._suppliersd, this._methodnm_GetDataByID, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { id, this._connectionb.ConnectionD }) as SuppliersM;
            return ConvertToSuppliers_B(result);
        }

        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="suppliers">供应商信息（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        ISuppliersB ConvertToSuppliers_B(SuppliersM suppliersm)
        {
            ISuppliersB result = null;
            if (suppliersm != null)
            {
                result = new SuppliersB(suppliersm, this._connectionb);
            }
            return result;
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {
            int effect = this._suppliersd.Update();
            return (effect > 0);
        }
        #endregion

    }
}
