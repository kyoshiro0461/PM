using PMModel;
using PMBLL.Instance;
using PM.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.Models
{
    /// <summary>
    /// 工程量信息工厂类（UI层）
    /// </summary>
    public class QuantityFactory
    {
        #region 常量
        const string GROUPNAME = "QuantityGroup";                             //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                            //Section名称
        #endregion
        #region 变量
        private IQuantityB _quantityb;                                           //工程量信息集合类（业务逻辑层）
        private QuantityM _quantitym;                                           //工程量类（模型层） 
        private ConnectionFactory _connectionfactory;                           //链接
        #endregion
        #region 属性
        /// <summary>
        /// 工程量信息
        /// </summary>
        public QuantityM Infomation_quantity
        {
            get { return this._quantitym; }
            set { this._quantitym = value; this._quantityb.Infomation_Quantity = this._quantitym; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public QuantityFactory()
        {
            this._connectionfactory = ViewMethods.GetConnection();
            InitFactory();
        }
        #endregion
        #region 方法
        /// <summary>
        /// 初始化工厂
        /// </summary>
        void InitFactory()
        {
            string strNameSpace = "", strInstance = "";
            ReadConfigFile(ref strNameSpace, ref strInstance);//读取配置文件
            InstanceObject(strNameSpace, strInstance);//实例化对象
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="strNameSpace">返回 命名空间字符串</param>
        /// <param name="strInstance">返回 实例字符串</param>
        void ReadConfigFile(ref string strNameSpace, ref string strInstance)
        {
            string configPath = Methods.CommonMethods.GetConfigPath();
            //读取配置文件的信息
            Sections.QuantitySection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.QuantitySection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例

            }
        }
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="strInstance">实例名</param>
        void InstanceObject(string strNameSpace, string strInstance)
        {
            this._quantityb = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionfactory.ConnectionB }) as IQuantityB;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>工程量信息（业务逻辑层）集合</returns>
        public List<IQuantityB> GetDataQuantity()
        {
            return this._quantityb.GetDataQuantity();
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
        /// <param name="belong">隶属</param>
        /// <returns></returns>
        public List<IQuantityB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway)
        {
            return this._quantityb.GetPageData(ref count, start, size, key, order, orderway);
        }

        /// <summary>
        /// 判断工程量是否存在
        /// </summary>
        /// <param name="quantityname">工程量名</param>
        /// <returns>工程量类</returns>
        public bool IsExist_quantityname(string quantityname)
        {
            bool isExist_quantityname = false;
            QuantityM quantitym = this._quantityb.IsExist_Quantityname(quantityname);
            if (quantitym != null)
            {
                this.Infomation_quantity = quantitym;
                isExist_quantityname = true;
            }
            return isExist_quantityname;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="userm">工程量信息类（模型层）</param>
        /// <returns>自动编号</returns>
        public bool Save()
        {
            return this._quantityb.Save();
        }

        /// <summary>
        /// 更新工程量信息
        /// </summary>
        /// <returns>T=更新成功；F=更新失败</returns>
        public int Del_Quantity()
        {
            return this._quantityb.Del_Quantity();
        }

        /// <summary>
        /// 通过工程量编号获取数据
        /// </summary>
        /// <param name="id">工程量编号</param>
        /// <returns>工程量信息（模型层）集合</returns>
        public IQuantityB GetDataByID(string id)
        {
            return this._quantityb.GetDataByID(id);
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {

            return this._quantityb.Update();
        }
        #endregion
    }
}