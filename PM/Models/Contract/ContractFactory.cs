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
    /// 合同信息工厂类（UI层）
    /// </summary>
    public class ContractFactory
    {
        #region 常量
        const string GROUPNAME = "ContractGroup";                             //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                            //Section名称
        #endregion
        #region 变量
        private IContractB _contractb;                                           //合同信息集合类（业务逻辑层）
        private ContractM _contractm;                                           //合同类（模型层） 
        private ConnectionFactory _connectionfactory;                           //链接
        #endregion
        #region 属性
        /// <summary>
        /// 合同信息
        /// </summary>
        public ContractM Infomation_contract
        {
            get { return this._contractm; }
            set { this._contractm = value; this._contractb.Infomation_contract = this._contractm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ContractFactory()
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
            Sections.ContractSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.ContractSection;
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
            this._contractb = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionfactory.ConnectionB }) as IContractB;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>合同信息（业务逻辑层）集合</returns>
        public List<IContractB> GetDataContract()
        {
            return this._contractb.GetDataContract();
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
        public List<IContractB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, string belong)
        {
            return this._contractb.GetPageData(ref count, start, size, key, order, orderway, belong);
        }

        /// <summary>
        /// 判断合同是否存在
        /// </summary>
        /// <param name="contractname">合同名</param>
        /// <returns>合同类</returns>
        public bool IsExist_contractname(string contractname)
        {
            bool isExist_contractname = false;
            ContractM contractm = this._contractb.IsExist_contractname(contractname);
            if (contractm != null)
            {
                this.Infomation_contract = contractm;
                isExist_contractname = true;
            }
            return isExist_contractname;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="userm">合同信息类（模型层）</param>
        /// <returns>自动编号</returns>
        public bool Save()
        {
            return this._contractb.Save();
        }

        /// <summary>
        /// 更新合同信息
        /// </summary>
        /// <returns>T=更新成功；F=更新失败</returns>
        public int Del_Contract()
        {
            return this._contractb.Del_Contract();
        }

        /// <summary>
        /// 通过合同编号获取数据
        /// </summary>
        /// <param name="id">合同编号</param>
        /// <returns>合同信息（模型层）集合</returns>
        public IContractB GetDataByID(string id)
        {
            return this._contractb.GetDataByID(id);
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {

            return this._contractb.Update();
        }
        #endregion
    }
}