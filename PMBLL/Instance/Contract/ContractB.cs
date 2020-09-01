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
    /// 合同信息类（业务逻辑层）
    /// </summary>
    public class ContractB : IContractB
    {
        #region 常量
        const string GROUPNAME = "ContractGroup";                           //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                       //Section名称
        #endregion
        #region 变量
        private IContractD _contractd;                                         //合同信息类（数据链路层）
        private string _methodnm_GetDefaultContract;                           //GetDefaultContract方法名
        private string _methodnm_GetPageData;                                 //GetPageData
        private string _methodnm_IsExist_contractname;                        //IsExist_contractname方法名
        private IConnectionB _connectionb;                                    //链接类（业务逻辑层）
        private ContractM _contractm;                                       //合同信息类（模型层）
        private string _methodnm_GetDataByID;                                 //GetDataByID方法名
        public ContractM Infomation_contract
        {
            get { return this._contractm; }
            set { this._contractm = value; this._contractd.Infomation_contract = this._contractm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectionb">链接类</param>
        public ContractB(IConnectionB connectionb)
        {
            this._connectionb = connectionb;
            InitObject();//初始化对象
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">合同信息类（模型层）</param>
        /// <param name="connectionb">链接类</param>
        public ContractB(ContractM info, IConnectionB connectionb)
            : this(connectionb)
        {
            this.Infomation_contract = info;
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
            Sections.ContractSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.ContractSection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
                this._methodnm_GetDefaultContract = section.GetDataContractMethod;   //GetDefaultContract方法名
                this._methodnm_GetPageData = section.GetPageDataMethod;
                this._methodnm_IsExist_contractname = section.IsExist_contractnameMethod;//IsExist_contractname方法名
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
            this._contractd = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionb.ConnectionD }) as ContractD;
        }
        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="lstContract">合同信息类（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        List<IContractB> ConvertToContractB(List<ContractM> lstContract)
        {
            List<IContractB> result = null;
            if (lstContract != null && lstContract.Count > 0)
            {
                result = new List<IContractB>();
                lstContract.ForEach(p => result.Add(new ContractB(this._connectionb) { Infomation_contract = p }));
            }
            return result;
        }
        /// <summary>
        /// 获取集团内合同集合数据
        /// </summary>
        /// <param >获取ContractN表集合数据</param>
        /// <returns>分类信息（业务逻辑层）集合</returns>
        public List<IContractB> GetDataContract()
        {
            //通过反射调用数据链路层的分类信息集合
            List<ContractM> lstContract = Methods.ReflexInvokeMethod(this._contractd, this._methodnm_GetDefaultContract, new Type[] { typeof(IConnectionD) }, new object[] { this._connectionb.ConnectionD }) as List<ContractM>;
            if (lstContract != null && lstContract.Count > 0) lstContract = lstContract.Where(p => true).ToList();
            return ConvertToContractB(lstContract);
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
            object[] args = new object[] { count, start, size, key, order, orderway, belong , this._connectionb.ConnectionD };
            List<ContractM> lstcontract = Methods.ReflexInvokeMethod(this._contractd, this._methodnm_GetPageData, new Type[] { typeof(long).MakeByRefType(), typeof(long), typeof(int), typeof(string), typeof(string),  typeof(OrderType), typeof(string), typeof(IConnectionD) }, args) as List<ContractM>;
            count = args[0].ConvertToInt64();
            return ConvertToContractB(lstcontract);
        }
        /// <summary>
        /// 判断集团内合同是否存在
        /// </summary>
        /// <param name="contractnname">集团内合同名</param>
        /// <returns>集团内合同信息类</returns>
        public ContractM IsExist_contractname(string contractname)
        {
            //通过反射调用数据链路层的用户类IsExist_username判断集团内合同是否存在
            return Methods.ReflexInvokeMethod(this._contractd, this._methodnm_IsExist_contractname, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { contractname, this._connectionb.ConnectionD }) as ContractM;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            return this._contractd.Save();//存档
        }

        /// <summary>
        /// 删除合同信息(Contract页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Del_Contract()
        {
            return this._contractd.Del_Contract();
        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>数据</returns>
        public IContractB GetDataByID(string id)
        {
            ContractM result = Methods.ReflexInvokeMethod(this._contractd, this._methodnm_GetDataByID, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { id, this._connectionb.ConnectionD }) as ContractM;
            return ConvertToContract_B(result);
        }

        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="contractn">集团内合同信息（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        IContractB ConvertToContract_B(ContractM contractm)
        {
            IContractB result = null;
            if (contractm != null)
            {
                result = new ContractB(contractm, this._connectionb);
            }
            return result;
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {
            int effect = this._contractd.Update();
            return (effect > 0);
        }
        #endregion

    }
}
