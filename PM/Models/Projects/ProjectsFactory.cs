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
    /// 项目信息工厂类（UI层）
    /// </summary>
    public class ProjectsFactory
    {
        #region 常量
        const string GROUPNAME = "ProjectsGroup";                             //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                            //Section名称
        #endregion
        #region 变量
        private IProjectsB _projectsb;                                           //项目信息集合类（业务逻辑层）
        private ProjectsM _projectsm;                                           //项目类（模型层） 
        private ConnectionFactory _connectionfactory;                           //链接
        #endregion
        #region 属性
        /// <summary>
        /// 项目信息
        /// </summary>
        public ProjectsM Infomation_projects
        {
            get { return this._projectsm; }
            set { this._projectsm = value; this._projectsb.Infomation_projects = this._projectsm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ProjectsFactory()
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
            Sections.ProjectsSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.ProjectsSection;
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
            this._projectsb = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionfactory.ConnectionB }) as IProjectsB;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>项目信息（业务逻辑层）集合</returns>
        public List<IProjectsB> GetDataProjects()
        {
            return this._projectsb.GetDataProjects();
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
        public List<IProjectsB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, string belong)
        {
            return this._projectsb.GetPageData(ref count, start, size, key, order, orderway, belong);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>活动分类信息（业务逻辑层）集合</returns>
        //public List<IProjectsB> AllGetData()
        //{
        //    return this._projectsb.AllGetData();
        //}


        /// <summary>
        /// 判断项目是否存在
        /// </summary>
        /// <param name="projectsname">项目名</param>
        /// <returns>项目类</returns>
        public bool IsExist_projectsname(string projectsname)
        {
            bool isExist_projectsname = false;
            ProjectsM projectsm = this._projectsb.IsExist_projectsname(projectsname);
            if (projectsm != null)
            {
                this.Infomation_projects = projectsm;
                isExist_projectsname = true;
            }
            return isExist_projectsname;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="userm">项目信息类（模型层）</param>
        /// <returns>自动编号</returns>
        public bool Save()
        {
            return this._projectsb.Save();
        }

        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <returns>T=更新成功；F=更新失败</returns>
        public int Del_Projects()
        {
            return this._projectsb.Del_Projects();
        }

        /// <summary>
        /// 通过项目编号获取数据
        /// </summary>
        /// <param name="id">项目编号</param>
        /// <returns>项目信息（模型层）集合</returns>
        public IProjectsB GetDataByID(string id)
        {
            return this._projectsb.GetDataByID(id);
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {

            return this._projectsb.Update();
        }
        #endregion
    }
}