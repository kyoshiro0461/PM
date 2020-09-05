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
    /// 客户信息工厂类（UI层）
    /// </summary>
    public class ClientsFactory
    {
        #region 常量
        const string GROUPNAME = "ClientsGroup";                             //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                         //Section名称
        #endregion
        #region 变量
        private IClientsB _clientsb;                                           //客户信息集合类（业务逻辑层）
        private ClientsM _clientsm;                                           //客户类（模型层） 
        private ConnectionFactory _connectionfactory;                    //链接
        #endregion
        #region 属性
        /// <summary>
        /// 客户信息
        /// </summary>
        public ClientsM Infomation_clients
        {
            get { return this._clientsm; }
            set { this._clientsm = value; this._clientsb.Infomation_clients = this._clientsm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ClientsFactory()
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
            Sections.ClientsSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.ClientsSection;
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
            this._clientsb = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionfactory.ConnectionB }) as IClientsB;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>后台菜单信息（业务逻辑层）集合</returns>
        public List<IClientsB> GetDataClients()
        {
            return this._clientsb.GetDataClients();
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
            return this._clientsb.GetPageData(ref count, start, size, key, order, orderway, belong);
        }

        /// <summary>
        /// 判断客户是否存在
        /// </summary>
        /// <param name="clientsname">客户名</param>
        /// <returns>客户类</returns>
        public bool IsExist_clientsname(string clientsname)
        {
            bool isExist_clientsname = false;
            ClientsM clientsm = this._clientsb.IsExist_clientsname(clientsname);
            if (clientsm != null)
            {
                this.Infomation_clients = clientsm;
                isExist_clientsname = true;
            }
            return isExist_clientsname;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="userm">客户信息类（模型层）</param>
        /// <returns>自动编号</returns>
        public bool Save()
        {
            return this._clientsb.Save();
        }

        /// <summary>
        /// 更新客户信息(禁用属性onoff)
        /// </summary>
        /// <returns>T=更新成功；F=更新失败</returns>
        public int Del_Clients()
        {
            return this._clientsb.Del_Clients();
        }

        /// <summary>
        /// 通过客户编号获取数据
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns>用户信息（模型层）集合</returns>
        public IClientsB GetDataByID(string id)
        {
            return this._clientsb.GetDataByID(id);
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {

            return this._clientsb.Update();
        }
        #endregion
    }
}