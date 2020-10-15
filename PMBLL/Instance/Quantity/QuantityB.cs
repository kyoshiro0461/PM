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
    /// 工程量信息类（业务逻辑层）
    /// </summary>
    public class QuantityB : IQuantityB
    {
        #region 常量
        const string GROUPNAME = "QuantityGroup";                           //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                       //Section名称
        #endregion
        #region 变量
        private IQuantityD _quantityd;                                         //工程量信息类（数据链路层）
        private string _methodnm_GetDefaultQuantity;                           //GetDefaultQuantity方法名
        private string _methodnm_GetPageData;                                 //GetPageData
        private string _methodnm_IsExist_Quantityname;                        //IsExist_Quantityname方法名
        private IConnectionB _connectionb;                                    //链接类（业务逻辑层）
        private QuantityM _quantitym;                                       //工程量信息类（模型层）
        private string _methodnm_GetDataByID;                                 //GetDataByID方法名
        public QuantityM Infomation_Quantity
        {
            get { return this._quantitym; }
            set { this._quantitym = value; this._quantityd.Infomation_Quantity = this._quantitym; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectionb">链接类</param>
        public QuantityB(IConnectionB connectionb)
        {
            this._connectionb = connectionb;
            InitObject();//初始化对象
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">收付款信息类（模型层）</param>
        /// <param name="connectionb">链接类</param>
        public QuantityB(QuantityM info, IConnectionB connectionb)
            : this(connectionb)
        {
            this.Infomation_Quantity = info;
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
            Sections.QuantitySection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.QuantitySection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
                this._methodnm_GetDefaultQuantity = section.GetDataQuantityMethod;   //GetDefaultQuantity方法名
                this._methodnm_GetPageData = section.GetPageDataMethod;
                this._methodnm_IsExist_Quantityname = section.IsExist_quantitynameMethod;//IsExist_Quantityname方法名
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
            this._quantityd = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionb.ConnectionD }) as QuantityD;
        }
        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="lstQuantity">收付款信息类（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        List<IQuantityB> ConvertToQuantityB(List<QuantityM> lstQuantity)
        {
            List<IQuantityB> result = null;
            if (lstQuantity != null && lstQuantity.Count > 0)
            {
                result = new List<IQuantityB>();
                lstQuantity.ForEach(p => result.Add(new QuantityB(this._connectionb) { Infomation_Quantity = p }));
            }
            return result;
        }
        /// <summary>
        /// 获取工程量集合数据
        /// </summary>
        /// <param >获取QuantityN表集合数据</param>
        /// <returns>分类信息（业务逻辑层）集合</returns>
        public List<IQuantityB> GetDataQuantity()
        {
            //通过反射调用数据链路层的分类信息集合
            List<QuantityM> lstQuantity = Methods.ReflexInvokeMethod(this._quantityd, this._methodnm_GetDefaultQuantity, new Type[] { typeof(IConnectionD) }, new object[] { this._connectionb.ConnectionD }) as List<QuantityM>;
            if (lstQuantity != null && lstQuantity.Count > 0) lstQuantity = lstQuantity.Where(p => true).ToList();
            return ConvertToQuantityB(lstQuantity);
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
        public List<IQuantityB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway)
        {
            object[] args = new object[] { count, start, size, key, order, orderway, this._connectionb.ConnectionD };
            List<QuantityM> lstquantity = Methods.ReflexInvokeMethod(this._quantityd, this._methodnm_GetPageData, new Type[] { typeof(long).MakeByRefType(), typeof(long), typeof(int), typeof(string), typeof(string),  typeof(OrderType), typeof(IConnectionD) }, args) as List<QuantityM>;
            count = args[0].ConvertToInt64();
            return ConvertToQuantityB(lstquantity);
        }
        /// <summary>
        /// 判断工程量是否存在
        /// </summary>
        /// <param name="quantityname">工程量名</param>
        /// <returns>工程量信息类</returns>
        public QuantityM IsExist_Quantityname(string quantityname)
        {
            //通过反射调用数据链路层的用户类IsExist_quantityname判断工程量是否存在
            return Methods.ReflexInvokeMethod(this._quantityd, this._methodnm_IsExist_Quantityname, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { quantityname, this._connectionb.ConnectionD }) as QuantityM;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            return this._quantityd.Save();//存档
        }

        /// <summary>
        /// 删除工程量信息(Quantity页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Del_Quantity()
        {
            return this._quantityd.Del_Quantity();
        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>数据</returns>
        public IQuantityB GetDataByID(string id)
        {
            QuantityM result = Methods.ReflexInvokeMethod(this._quantityd, this._methodnm_GetDataByID, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { id, this._connectionb.ConnectionD }) as QuantityM;
            return ConvertToQuantity_B(result);
        }

        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="financen">工程量信息（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        IQuantityB ConvertToQuantity_B(QuantityM quantitym)
        {
            IQuantityB result = null;
            if (quantitym != null)
            {
                result = new QuantityB(quantitym, this._connectionb);
            }
            return result;
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {
            int effect = this._quantityd.Update();
            return (effect > 0);
        }
        #endregion

    }
}
