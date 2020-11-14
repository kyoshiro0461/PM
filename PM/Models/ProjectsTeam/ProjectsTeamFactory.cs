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
    public class ProjectsTeamFactory
    {
        #region 常量
        const string GROUPNAME = "ProjectsTeamGroup";                             //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                            //Section名称
        #endregion
        #region 变量
        private IProjectsTeamB _projectsteamb;                                           //项目信息集合类（业务逻辑层）
        private ProjectsTeamM _projectsteamm;                                           //项目类（模型层） 
        private ConnectionFactory _connectionfactory;                           //链接
        #endregion
        #region 属性
        /// <summary>
        /// 项目信息
        /// </summary>
        public ProjectsTeamM Infomation_projectsteam
        {
            get { return this._projectsteamm; }
            set { this._projectsteamm = value; this._projectsteamb.Infomation_projectsteam = this._projectsteamm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ProjectsTeamFactory()
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
            Sections.ProjectsTeamSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.ProjectsTeamSection;
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
            this._projectsteamb = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionfactory.ConnectionB }) as IProjectsTeamB;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>项目信息（业务逻辑层）集合</returns>
        public List<IProjectsTeamB> GetDataProjectsTeam()
        {
            return this._projectsteamb.GetDataProjectsTeam();
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
        public List<IProjectsTeamB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, string belong)
        {
            return this._projectsteamb.GetPageData(ref count, start, size, key, order, orderway, belong);
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
        public bool IsExist_projectsteamname(string projectsteamname)
        {
            bool isExist_projectsteamname = false;
            ProjectsTeamM projectsteamm = this._projectsteamb.IsExist_projectsteamname(projectsteamname);
            if (projectsteamm != null)
            {
                this.Infomation_projectsteam = projectsteamm;
                isExist_projectsteamname = true;
            }
            return isExist_projectsteamname;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="userm">项目信息类（模型层）</param>
        /// <returns>自动编号</returns>
        public bool Save()
        {
            return this._projectsteamb.Save();
        }

        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <returns>T=更新成功；F=更新失败</returns>
        public int Del_ProjectsTeam()
        {
            return this._projectsteamb.Del_ProjectsTeam();
        }

        /// <summary>
        /// 通过项目编号获取数据
        /// </summary>
        /// <param name="id">项目编号</param>
        /// <returns>项目信息（模型层）集合</returns>
        public IProjectsTeamB GetDataByID(string id)
        {
            return this._projectsteamb.GetDataByID(id);
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {

            return this._projectsteamb.Update();
        }
        #endregion
    }
}