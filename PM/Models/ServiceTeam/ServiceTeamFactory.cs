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
    /// 业主信息工厂类（UI层）
    /// </summary>
    public class ServiceTeamFactory
    {
        #region 常量
        const string GROUPNAME = "ServiceTeamGroup";                             //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                         //Section名称
        #endregion
        #region 变量
        private IServiceTeamB _serviceteamb;                                           //业主信息集合类（业务逻辑层）
        private ServiceTeamM _serviceteamm;                                           //业主类（模型层） 
        private ConnectionFactory _connectionfactory;                    //链接
        #endregion
        #region 属性
        /// <summary>
        /// 业主信息
        /// </summary>
        public ServiceTeamM Infomation_serviceteam
        {
            get { return this._serviceteamm; }
            set { this._serviceteamm = value; this._serviceteamb.Infomation_serviceteam = this._serviceteamm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ServiceTeamFactory()
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
            Sections.ServiceTeamSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.ServiceTeamSection;
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
            this._serviceteamb = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionfactory.ConnectionB }) as IServiceTeamB;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>后台菜单信息（业务逻辑层）集合</returns>
        public List<IServiceTeamB> GetDataServiceTeam()
        {
            return this._serviceteamb.GetDataServiceTeam();
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
        public List<IServiceTeamB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway)
        {
            return this._serviceteamb.GetPageData(ref count, start, size, key, order, orderway);
        }

        /// <summary>
        /// 判断业主是否存在
        /// </summary>
        /// <param name="serviceteamname">业主名</param>
        /// <returns>业主类</returns>
        public bool IsExist_serviceteamname(string serviceteamname)
        {
            bool isExist_serviceteamname = false;
            ServiceTeamM serviceteamm = this._serviceteamb.IsExist_serviceteamname(serviceteamname);
            if (serviceteamm != null)
            {
                this.Infomation_serviceteam = serviceteamm;
                isExist_serviceteamname = true;
            }
            return isExist_serviceteamname;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="userm">业主信息类（模型层）</param>
        /// <returns>自动编号</returns>
        public bool Save()
        {
            return this._serviceteamb.Save();
        }

        /// <summary>
        /// 更新业主信息(禁用属性onoff)
        /// </summary>
        /// <returns>T=更新成功；F=更新失败</returns>
        public int Del_ServiceTeam()
        {
            return this._serviceteamb.Del_ServiceTeam();
        }

        /// <summary>
        /// 通过业主编号获取数据
        /// </summary>
        /// <param name="id">业主编号</param>
        /// <returns>用户信息（模型层）集合</returns>
        public IServiceTeamB GetDataByID(string id)
        {
            return this._serviceteamb.GetDataByID(id);
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {

            return this._serviceteamb.Update();
        }
        #endregion
    }
}