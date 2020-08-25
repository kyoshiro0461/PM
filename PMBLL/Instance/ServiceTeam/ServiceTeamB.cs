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
    /// 劳务队信息类（业务逻辑层）
    /// </summary>
    public class ServiceTeamB : IServiceTeamB
    {
        #region 常量
        const string GROUPNAME = "ServiceTeamGroup";                           //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                       //Section名称
        #endregion
        #region 变量
        private IServiceTeamD _serviceteamd;                                         //劳务队信息类（数据链路层）
        private string _methodnm_GetDefaultServiceTeam;                       //GetDefaultServiceTeam方法名
        private string _methodnm_GetPageData;                          //GetPageData
        private string _methodnm_IsExist_serviceteamname;                    //IsExist_serviceteamname方法名
        private IConnectionB _connectionb;                            //链接类（业务逻辑层）
        private ServiceTeamM _serviceteamm;                                         //劳务队信息类（模型层）
        private string _methodnm_GetDataByID;                         //GetDataByID方法名
        public ServiceTeamM Infomation_serviceteam
        {
            get { return this._serviceteamm; }
            set { this._serviceteamm = value; this._serviceteamd.Infomation_serviceteam = this._serviceteamm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectionb">链接类</param>
        public ServiceTeamB(IConnectionB connectionb)
        {
            this._connectionb = connectionb;
            InitObject();//初始化对象
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">劳务队信息类（模型层）</param>
        /// <param name="connectionb">链接类</param>
        public ServiceTeamB(ServiceTeamM info, IConnectionB connectionb)
            : this(connectionb)
        {
            this.Infomation_serviceteam = info;
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
            Sections.ServiceTeamSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.ServiceTeamSection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
                this._methodnm_GetDefaultServiceTeam = section.GetDataServiceTeamMethod;   //GetDefaultServiceTeam方法名
                this._methodnm_GetPageData = section.GetPageDataMethod;
                this._methodnm_IsExist_serviceteamname = section.IsExist_serviceteamnameMethod;//IsExist_serviceteamname方法名
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
            this._serviceteamd = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionb.ConnectionD }) as ServiceTeamD;
        }
        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="lstServiceTeam">劳务队信息类（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        List<IServiceTeamB> ConvertToServiceTeamB(List<ServiceTeamM> lstServiceTeam)
        {
            List<IServiceTeamB> result = null;
            if (lstServiceTeam != null && lstServiceTeam.Count > 0)
            {
                result = new List<IServiceTeamB>();
                lstServiceTeam.ForEach(p => result.Add(new ServiceTeamB(this._connectionb) { Infomation_serviceteam = p }));
            }
            return result;
        }
        /// <summary>
        /// 获取劳务队集合数据
        /// </summary>
        /// <param >获取ServiceTeam表集合数据</param>
        /// <returns>分类信息（业务逻辑层）集合</returns>
        public List<IServiceTeamB> GetDataServiceTeam()
        {
            //通过反射调用数据链路层的分类信息集合
            List<ServiceTeamM> lstServiceTeam = Methods.ReflexInvokeMethod(this._serviceteamd, this._methodnm_GetDefaultServiceTeam, new Type[] { typeof(IConnectionD) }, new object[] { this._connectionb.ConnectionD }) as List<ServiceTeamM>;
            if (lstServiceTeam != null && lstServiceTeam.Count > 0) lstServiceTeam = lstServiceTeam.Where(p => true).ToList();
            return ConvertToServiceTeamB(lstServiceTeam);
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
            object[] args = new object[] { count, start, size, key, order, orderway, this._connectionb.ConnectionD };
            List<ServiceTeamM> lstserviceteam = Methods.ReflexInvokeMethod(this._serviceteamd, this._methodnm_GetPageData, new Type[] { typeof(long).MakeByRefType(), typeof(long), typeof(int), typeof(string), typeof(string), typeof(OrderType), typeof(IConnectionD) }, args) as List<ServiceTeamM>;
            count = args[0].ConvertToInt64();
            return ConvertToServiceTeamB(lstserviceteam);
        }
        /// <summary>
        /// 判断劳务队是否存在
        /// </summary>
        /// <param name="serviceteamname">劳务队名</param>
        /// <returns>劳务队信息类</returns>
        public ServiceTeamM IsExist_serviceteamname(string serviceteamname)
        {
            //通过反射调用数据链路层的用户类IsExist_username判断劳务队是否存在
            return Methods.ReflexInvokeMethod(this._serviceteamd, this._methodnm_IsExist_serviceteamname, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { serviceteamname, this._connectionb.ConnectionD }) as ServiceTeamM;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            return this._serviceteamd.Save();//存档
        }

        /// <summary>
        /// 删除劳务队信息(ServiceTeam页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Del_ServiceTeam()
        {
            return this._serviceteamd.Del_ServiceTeam();
        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>数据</returns>
        public IServiceTeamB GetDataByID(string id)
        {
            ServiceTeamM result = Methods.ReflexInvokeMethod(this._serviceteamd, this._methodnm_GetDataByID, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { id, this._connectionb.ConnectionD }) as ServiceTeamM;
            return ConvertToServiceTeam_B(result);
        }

        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="serviceteam">劳务队信息（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        IServiceTeamB ConvertToServiceTeam_B(ServiceTeamM serviceteamm)
        {
            IServiceTeamB result = null;
            if (serviceteamm != null)
            {
                result = new ServiceTeamB(serviceteamm, this._connectionb);
            }
            return result;
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {
            int effect = this._serviceteamd.Update();
            return (effect > 0);
        }
        #endregion

    }
}
