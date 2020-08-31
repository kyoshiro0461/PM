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
    public class ProjectsB : IProjectsB
    {
        #region 常量
        const string GROUPNAME = "ProjectsGroup";                           //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                       //Section名称
        #endregion
        #region 变量
        private IProjectsD _projectsd;                                         //项目信息类（数据链路层）
        private string _methodnm_GetDefaultProjects;                           //GetDefaultProjects方法名
        private string _methodnm_GetPageData;                                 //GetPageData
        private string _methodnm_IsExist_projectsname;                        //IsExist_projectsname方法名
        private IConnectionB _connectionb;                                    //链接类（业务逻辑层）
        private ProjectsM _projectsm;                                       //项目信息类（模型层）
        private string _methodnm_GetDataByID;                                 //GetDataByID方法名
        public ProjectsM Infomation_projects
        {
            get { return this._projectsm; }
            set { this._projectsm = value; this._projectsd.Infomation_projects = this._projectsm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectionb">链接类</param>
        public ProjectsB(IConnectionB connectionb)
        {
            this._connectionb = connectionb;
            InitObject();//初始化对象
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">项目信息类（模型层）</param>
        /// <param name="connectionb">链接类</param>
        public ProjectsB(ProjectsM info, IConnectionB connectionb)
            : this(connectionb)
        {
            this.Infomation_projects = info;
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
            Sections.ProjectsSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.ProjectsSection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
                this._methodnm_GetDefaultProjects = section.GetDataProjectsMethod;   //GetDefaultProjects方法名
                this._methodnm_GetPageData = section.GetPageDataMethod;
                this._methodnm_IsExist_projectsname = section.IsExist_projectsnameMethod;//IsExist_projectsname方法名
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
            this._projectsd = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionb.ConnectionD }) as ProjectsD;
        }
        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="lstProjects">项目信息类（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        List<IProjectsB> ConvertToProjectsB(List<ProjectsM> lstProjects)
        {
            List<IProjectsB> result = null;
            if (lstProjects != null && lstProjects.Count > 0)
            {
                result = new List<IProjectsB>();
                lstProjects.ForEach(p => result.Add(new ProjectsB(this._connectionb) { Infomation_projects = p }));
            }
            return result;
        }
        /// <summary>
        /// 获取集团内项目集合数据
        /// </summary>
        /// <param >获取ProjectsN表集合数据</param>
        /// <returns>分类信息（业务逻辑层）集合</returns>
        public List<IProjectsB> GetDataProjects()
        {
            //通过反射调用数据链路层的分类信息集合
            List<ProjectsM> lstProjects = Methods.ReflexInvokeMethod(this._projectsd, this._methodnm_GetDefaultProjects, new Type[] { typeof(IConnectionD) }, new object[] { this._connectionb.ConnectionD }) as List<ProjectsM>;
            if (lstProjects != null && lstProjects.Count > 0) lstProjects = lstProjects.Where(p => true).ToList();
            return ConvertToProjectsB(lstProjects);
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
        public List<IProjectsB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, string belong)
        {
            object[] args = new object[] { count, start, size, key, order, orderway, belong , this._connectionb.ConnectionD };
            List<ProjectsM> lstprojects = Methods.ReflexInvokeMethod(this._projectsd, this._methodnm_GetPageData, new Type[] { typeof(long).MakeByRefType(), typeof(long), typeof(int), typeof(string), typeof(string),  typeof(OrderType), typeof(string), typeof(IConnectionD) }, args) as List<ProjectsM>;
            count = args[0].ConvertToInt64();
            return ConvertToProjectsB(lstprojects);
        }
        /// <summary>
        /// 判断集团内项目是否存在
        /// </summary>
        /// <param name="projectsnname">集团内项目名</param>
        /// <returns>集团内项目信息类</returns>
        public ProjectsM IsExist_projectsname(string projectsname)
        {
            //通过反射调用数据链路层的用户类IsExist_username判断集团内项目是否存在
            return Methods.ReflexInvokeMethod(this._projectsd, this._methodnm_IsExist_projectsname, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { projectsname, this._connectionb.ConnectionD }) as ProjectsM;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            return this._projectsd.Save();//存档
        }

        /// <summary>
        /// 删除项目信息(Projects页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Del_Projects()
        {
            return this._projectsd.Del_Projects();
        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>数据</returns>
        public IProjectsB GetDataByID(string id)
        {
            ProjectsM result = Methods.ReflexInvokeMethod(this._projectsd, this._methodnm_GetDataByID, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { id, this._connectionb.ConnectionD }) as ProjectsM;
            return ConvertToProjects_B(result);
        }

        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="projectsn">集团内项目信息（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        IProjectsB ConvertToProjects_B(ProjectsM projectsm)
        {
            IProjectsB result = null;
            if (projectsm != null)
            {
                result = new ProjectsB(projectsm, this._connectionb);
            }
            return result;
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {
            int effect = this._projectsd.Update();
            return (effect > 0);
        }
        #endregion

    }
}
