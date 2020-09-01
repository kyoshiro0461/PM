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
    /// 集团内收付款信息类（业务逻辑层）
    /// </summary>
    public class FinanceB : IFinanceB
    {
        #region 常量
        const string GROUPNAME = "FinanceGroup";                           //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                       //Section名称
        #endregion
        #region 变量
        private IFinanceD _financed;                                         //收付款信息类（数据链路层）
        private string _methodnm_GetDefaultFinance;                           //GetDefaultFinance方法名
        private string _methodnm_GetPageData;                                 //GetPageData
        private string _methodnm_IsExist_financename;                        //IsExist_financename方法名
        private IConnectionB _connectionb;                                    //链接类（业务逻辑层）
        private FinanceM _financem;                                       //收付款信息类（模型层）
        private string _methodnm_GetDataByID;                                 //GetDataByID方法名
        public FinanceM Infomation_finance
        {
            get { return this._financem; }
            set { this._financem = value; this._financed.Infomation_finance = this._financem; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectionb">链接类</param>
        public FinanceB(IConnectionB connectionb)
        {
            this._connectionb = connectionb;
            InitObject();//初始化对象
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">收付款信息类（模型层）</param>
        /// <param name="connectionb">链接类</param>
        public FinanceB(FinanceM info, IConnectionB connectionb)
            : this(connectionb)
        {
            this.Infomation_finance = info;
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
            Sections.FinanceSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.FinanceSection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
                this._methodnm_GetDefaultFinance = section.GetDataFinanceMethod;   //GetDefaultFinance方法名
                this._methodnm_GetPageData = section.GetPageDataMethod;
                this._methodnm_IsExist_financename = section.IsExist_financenameMethod;//IsExist_financename方法名
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
            this._financed = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionb.ConnectionD }) as FinanceD;
        }
        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="lstFinance">收付款信息类（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        List<IFinanceB> ConvertToFinanceB(List<FinanceM> lstFinance)
        {
            List<IFinanceB> result = null;
            if (lstFinance != null && lstFinance.Count > 0)
            {
                result = new List<IFinanceB>();
                lstFinance.ForEach(p => result.Add(new FinanceB(this._connectionb) { Infomation_finance = p }));
            }
            return result;
        }
        /// <summary>
        /// 获取集团内收付款集合数据
        /// </summary>
        /// <param >获取FinanceN表集合数据</param>
        /// <returns>分类信息（业务逻辑层）集合</returns>
        public List<IFinanceB> GetDataFinance()
        {
            //通过反射调用数据链路层的分类信息集合
            List<FinanceM> lstFinance = Methods.ReflexInvokeMethod(this._financed, this._methodnm_GetDefaultFinance, new Type[] { typeof(IConnectionD) }, new object[] { this._connectionb.ConnectionD }) as List<FinanceM>;
            if (lstFinance != null && lstFinance.Count > 0) lstFinance = lstFinance.Where(p => true).ToList();
            return ConvertToFinanceB(lstFinance);
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
        public List<IFinanceB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, string belong)
        {
            object[] args = new object[] { count, start, size, key, order, orderway, belong , this._connectionb.ConnectionD };
            List<FinanceM> lstfinance = Methods.ReflexInvokeMethod(this._financed, this._methodnm_GetPageData, new Type[] { typeof(long).MakeByRefType(), typeof(long), typeof(int), typeof(string), typeof(string),  typeof(OrderType), typeof(string), typeof(IConnectionD) }, args) as List<FinanceM>;
            count = args[0].ConvertToInt64();
            return ConvertToFinanceB(lstfinance);
        }
        /// <summary>
        /// 判断集团内收付款是否存在
        /// </summary>
        /// <param name="financenname">集团内收付款名</param>
        /// <returns>集团内收付款信息类</returns>
        public FinanceM IsExist_financename(string financename)
        {
            //通过反射调用数据链路层的用户类IsExist_username判断集团内收付款是否存在
            return Methods.ReflexInvokeMethod(this._financed, this._methodnm_IsExist_financename, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { financename, this._connectionb.ConnectionD }) as FinanceM;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            return this._financed.Save();//存档
        }

        /// <summary>
        /// 删除收付款信息(Finance页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Del_Finance()
        {
            return this._financed.Del_Finance();
        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>数据</returns>
        public IFinanceB GetDataByID(string id)
        {
            FinanceM result = Methods.ReflexInvokeMethod(this._financed, this._methodnm_GetDataByID, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { id, this._connectionb.ConnectionD }) as FinanceM;
            return ConvertToFinance_B(result);
        }

        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="financen">集团内收付款信息（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        IFinanceB ConvertToFinance_B(FinanceM financem)
        {
            IFinanceB result = null;
            if (financem != null)
            {
                result = new FinanceB(financem, this._connectionb);
            }
            return result;
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {
            int effect = this._financed.Update();
            return (effect > 0);
        }
        #endregion

    }
}
