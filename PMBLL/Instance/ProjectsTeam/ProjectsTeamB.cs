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
    /// 集团内项目信息类（业务逻辑层）
    /// </summary>
    public class ProjectsTeamB : IProjectsTeamB
    {
        #region 常量
        const string GROUPNAME = "ProjectsTeamGroup";                           //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                       //Section名称
        #endregion
        #region 变量
        private IProjectsTeamD _projectsteamd;                                         //项目信息类（数据链路层）
        private string _methodnm_GetDefaultProjectsTeam;                           //GetDefaultProjects方法名
        private string _methodnm_GetPageData;                                 //GetPageData
        //private string _methodnm_GetData;                                      //GetData方法名
        private string _methodnm_IsExist_projectsteamname;                        //IsExist_projectsname方法名
        private IConnectionB _connectionb;                                    //链接类（业务逻辑层）
        private ProjectsTeamM _projectsteamm;                                       //项目信息类（模型层）
        private string _methodnm_GetDataByID;                                 //GetDataByID方法名
        public ProjectsTeamM Infomation_projectsteam
        {
            get { return this._projectsteamm; }
            set { this._projectsteamm = value; this._projectsteamd.Infomation_projectsteam = this._projectsteamm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectionb">链接类</param>
        public ProjectsTeamB(IConnectionB connectionb)
        {
            this._connectionb = connectionb;
            InitObject();//初始化对象
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">项目信息类（模型层）</param>
        /// <param name="connectionb">链接类</param>
        public ProjectsTeamB(ProjectsTeamM info, IConnectionB connectionb)
            : this(connectionb)
        {
            this.Infomation_projectsteam = info;
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
            Sections.ProjectsTeamSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.ProjectsTeamSection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
                this._methodnm_GetDefaultProjectsTeam = section.GetDataProjectsTeamMethod;   //GetDefaultProjects方法名
                
                this._methodnm_GetPageData = section.GetPageDataMethod;
                this._methodnm_IsExist_projectsteamname = section.IsExist_projectsteamnameMethod;//IsExist_projectsname方法名
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
            this._projectsteamd = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionb.ConnectionD }) as ProjectsTeamD;
        }
        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="lstProjects">项目信息类（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        List<IProjectsTeamB> ConvertToProjectsTeamB(List<ProjectsTeamM> lstProjectsteam)
        {
            List<IProjectsTeamB> result = null;
            if (lstProjectsteam != null && lstProjectsteam.Count > 0)
            {
                result = new List<IProjectsTeamB>();
                lstProjectsteam.ForEach(p => result.Add(new ProjectsTeamB(this._connectionb) { Infomation_projectsteam = p }));
            }
            return result;
        }
        /// <summary>
        /// 获取集团内项目集合数据
        /// </summary>
        /// <param >获取ProjectsN表集合数据</param>
        /// <returns>分类信息（业务逻辑层）集合</returns>
        public List<IProjectsTeamB> GetDataProjectsTeam()
        {
            //通过反射调用数据链路层的分类信息集合
            List<ProjectsTeamM> lstProjectsteam = Methods.ReflexInvokeMethod(this._projectsteamd, this._methodnm_GetDefaultProjectsTeam, new Type[] { typeof(IConnectionD) }, new object[] { this._connectionb.ConnectionD }) as List<ProjectsTeamM>;
            if (lstProjectsteam != null && lstProjectsteam.Count > 0) lstProjectsteam = lstProjectsteam.Where(p => true).ToList();
            return ConvertToProjectsTeamB(lstProjectsteam);
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
        public List<IProjectsTeamB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, string belong)
        {
            object[] args = new object[] { count, start, size, key, order, orderway, belong , this._connectionb.ConnectionD };
            List<ProjectsTeamM> lstprojectsteam = Methods.ReflexInvokeMethod(this._projectsteamd, this._methodnm_GetPageData, new Type[] { typeof(long).MakeByRefType(), typeof(long), typeof(int), typeof(string), typeof(string),  typeof(OrderType), typeof(string), typeof(IConnectionD) }, args) as List<ProjectsTeamM>;
            count = args[0].ConvertToInt64();
            return ConvertToProjectsTeamB(lstprojectsteam);
        }

        
        /// <summary>
        /// 判断集团内项目是否存在
        /// </summary>
        /// <param name="projectsnname">集团内项目名</param>
        /// <returns>集团内项目信息类</returns>
        public ProjectsTeamM IsExist_projectsteamname(string projectsteamname)
        {
            //通过反射调用数据链路层的用户类IsExist_username判断集团内项目是否存在
            return Methods.ReflexInvokeMethod(this._projectsteamd, this._methodnm_IsExist_projectsteamname, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { projectsteamname, this._connectionb.ConnectionD }) as ProjectsTeamM;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            return this._projectsteamd.Save();//存档
        }

        /// <summary>
        /// 删除项目信息(Projects页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Del_ProjectsTeam()
        {
            return this._projectsteamd.Del_ProjectsTeam();
        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>数据</returns>
        public IProjectsTeamB GetDataByID(string id)
        {
            ProjectsTeamM result = Methods.ReflexInvokeMethod(this._projectsteamd, this._methodnm_GetDataByID, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { id, this._connectionb.ConnectionD }) as ProjectsTeamM;
            return ConvertToProjectsTeam_B(result);
        }

        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="projectsn">集团内项目信息（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        IProjectsTeamB ConvertToProjectsTeam_B(ProjectsTeamM projectsteamm)
        {
            IProjectsTeamB result = null;
            if (projectsteamm != null)
            {
                result = new ProjectsTeamB(projectsteamm, this._connectionb);
            }
            return result;
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {
            int effect = this._projectsteamd.Update();
            return (effect > 0);
        }
        #endregion

    }
}
