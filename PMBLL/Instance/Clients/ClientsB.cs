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
    /// 业主信息类（业务逻辑层）
    /// </summary>
    public class ClientsB : IClientsB
    {
        #region 常量
        const string GROUPNAME = "ClientsGroup";                           //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                       //Section名称
        #endregion
        #region 变量
        private IClientsD _clientsd;                                         //客户信息类（数据链路层）
        private string _methodnm_GetDefaultClients;                            //GetDefaultClients方法名
        private string _methodnm_GetPageData;                              //GetPageData
        private string _methodnm_IsExist_clientsname;                    //IsExist_clientsname方法名
        private IConnectionB _connectionb;                            //链接类（业务逻辑层）
        private ClientsM _clientsm;                                         //业主信息类（模型层）
        private string _methodnm_GetDataByID;                         //GetDataByID方法名
        public ClientsM Infomation_clients
        {
            get { return this._clientsm; }
            set { this._clientsm = value; this._clientsd.Infomation_clients = this._clientsm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectionb">链接类</param>
        public ClientsB(IConnectionB connectionb)
        {
            this._connectionb = connectionb;
            InitObject();//初始化对象
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">业主信息类（模型层）</param>
        /// <param name="connectionb">链接类</param>
        public ClientsB(ClientsM info, IConnectionB connectionb)
            : this(connectionb)
        {
            this.Infomation_clients = info;
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
            Sections.ClientsSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.ClientsSection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
                this._methodnm_GetDefaultClients = section.GetDataClientsMethod;   //GetDefaultClients方法名
                this._methodnm_GetPageData = section.GetPageDataMethod;
                this._methodnm_IsExist_clientsname = section.IsExist_clientsnameMethod;//IsExist_clientsname方法名
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
            this._clientsd = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionb.ConnectionD }) as ClientsD;
        }
        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="lstClients">客户信息类（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        List<IClientsB> ConvertToClientsB(List<ClientsM> lstClients)
        {
            List<IClientsB> result = null;
            if (lstClients != null && lstClients.Count > 0)
            {
                result = new List<IClientsB>();
                lstClients.ForEach(p => result.Add(new ClientsB(this._connectionb) { Infomation_clients = p }));
            }
            return result;
        }
        /// <summary>
        /// 获取客户集合数据
        /// </summary>
        /// <param >获取Clients表集合数据</param>
        /// <returns>分类信息（业务逻辑层）集合</returns>
        public List<IClientsB> GetDataClients()
        {
            //通过反射调用数据链路层的分类信息集合
            List<ClientsM> lstClients = Methods.ReflexInvokeMethod(this._clientsd, this._methodnm_GetDefaultClients, new Type[] { typeof(IConnectionD) }, new object[] { this._connectionb.ConnectionD }) as List<ClientsM>;
            if (lstClients != null && lstClients.Count > 0) lstClients = lstClients.Where(p => true).ToList();
            return ConvertToClientsB(lstClients);
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
        public List<IClientsB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, string belong)
        {
            object[] args = new object[] { count, start, size, key, order, orderway, belong, this._connectionb.ConnectionD };
            List<ClientsM> lstclients = Methods.ReflexInvokeMethod(this._clientsd, this._methodnm_GetPageData, new Type[] { typeof(long).MakeByRefType(), typeof(long), typeof(int), typeof(string), typeof(string), typeof(OrderType), typeof(string), typeof(IConnectionD) }, args) as List<ClientsM>;
            count = args[0].ConvertToInt64();
            return ConvertToClientsB(lstclients);
        }
        /// <summary>
        /// 判断客户是否存在
        /// </summary>
        /// <param name="clientsname">业主名</param>
        /// <returns>业主信息类</returns>
        public ClientsM IsExist_clientsname(string clientsname, string id)
        {
            //通过反射调用数据链路层的用户类IsExist_clientsname判断客户是否存在
            return Methods.ReflexInvokeMethod(this._clientsd, this._methodnm_IsExist_clientsname, new Type[] { typeof(String), typeof(string),  typeof(IConnectionD) }, new object[] { clientsname, id, this._connectionb.ConnectionD }) as ClientsM;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            return this._clientsd.Save();//存档
        }

        /// <summary>
        /// 删除客户信息(Clients页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Del_Clients()
        {
            return this._clientsd.Del_Clients();
        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>数据</returns>
        public IClientsB GetDataByID(string id)
        {
            ClientsM result = Methods.ReflexInvokeMethod(this._clientsd, this._methodnm_GetDataByID, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { id, this._connectionb.ConnectionD }) as ClientsM;
            return ConvertToClients_B(result);
        }

        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="clients">客户信息（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        IClientsB ConvertToClients_B(ClientsM clientsm)
        {
            IClientsB result = null;
            if (clientsm != null)
            {
                result = new ClientsB(clientsm, this._connectionb);
            }
            return result;
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {
            int effect = this._clientsd.Update();
            return (effect > 0);
        }
        #endregion

    }
}
