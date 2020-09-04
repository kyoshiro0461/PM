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
    /// 收付款信息工厂类（UI层）
    /// </summary>
    public class FinanceFactory
    {
        #region 常量
        const string GROUPNAME = "FinanceGroup";                             //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                            //Section名称
        #endregion
        #region 变量
        private IFinanceB _financeb;                                           //收付款信息集合类（业务逻辑层）
        private FinanceM _financem;                                           //收付款类（模型层） 
        private ConnectionFactory _connectionfactory;                           //链接
        #endregion
        #region 属性
        /// <summary>
        /// 收付款信息
        /// </summary>
        public FinanceM Infomation_finance
        {
            get { return this._financem; }
            set { this._financem = value; this._financeb.Infomation_finance = this._financem; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public FinanceFactory()
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
            Sections.FinanceSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.FinanceSection;
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
            this._financeb = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionfactory.ConnectionB }) as IFinanceB;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>收付款信息（业务逻辑层）集合</returns>
        public List<IFinanceB> GetDataFinance()
        {
            return this._financeb.GetDataFinance();
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
        public List<IFinanceB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, string belong)
        {
            return this._financeb.GetPageData(ref count, start, size, key, order, orderway, belong);
        }

        /// <summary>
        /// 判断收付款是否存在
        /// </summary>
        /// <param name="financename">收付款名</param>
        /// <returns>收付款类</returns>
        public bool IsExist_financename(string financename)
        {
            bool isExist_financename = false;
            FinanceM financem = this._financeb.IsExist_financename(financename);
            if (financem != null)
            {
                this.Infomation_finance = financem;
                isExist_financename = true;
            }
            return isExist_financename;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="userm">收付款信息类（模型层）</param>
        /// <returns>自动编号</returns>
        public bool Save()
        {
            return this._financeb.Save();
        }

        /// <summary>
        /// 更新收付款信息
        /// </summary>
        /// <returns>T=更新成功；F=更新失败</returns>
        public int Del_Finance()
        {
            return this._financeb.Del_Finance();
        }

        /// <summary>
        /// 通过收付款编号获取数据
        /// </summary>
        /// <param name="id">收付款编号</param>
        /// <returns>收付款信息（模型层）集合</returns>
        public IFinanceB GetDataByID(string id)
        {
            return this._financeb.GetDataByID(id);
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {

            return this._financeb.Update();
        }
        #endregion
    }
}