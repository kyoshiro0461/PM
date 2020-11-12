using PMDAL.DataBase;
using PMModel;
using PublicMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDAL.Instance
{
    /// <summary>
    /// 集团内项目信息类（数据链路层）
    /// </summary>
    public class ProjectsTeamD : IProjectsTeamD
    {
        #region 变量
        private DbFactoryD _dbfactory;                          //数据库工厂类
        private ProjectsTeamM _projectsteamm;                                   //项目信息类（模型层）
        private IConnectionD _connectiond;                      //链接类
        #endregion
        #region 属性
        /// <summary>
        /// 集团内项目信息类（模型层）
        /// </summary>
        public ProjectsTeamM Infomation_projectsteam
        {
            set { this._projectsteamm = value; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectiond">链接类</param>
        public ProjectsTeamD(IConnectionD connectiond)
        {
            this._connectiond = connectiond;
            this._dbfactory = connectiond.DataBaseFactory;
        }
        #endregion
        #region 方法
        /// <summary>
        /// 获取字段
        /// </summary>
        /// <param name="alias">表别名</param>
        /// <returns>字段</returns>
        public static string GetField(string alias = "")
        {
            string result = string.Format("[#alias]{0}[#as]{0}, [#alias]{1}[#as]{1}",
                TableStructM.Info_ProjectTeam.PT_ID, TableStructM.Info_ProjectTeam.PT_NAME);
            result = result.Replace("[#alias]", (string.IsNullOrEmpty(alias) ? "" : string.Format("{0}.", alias)));
            result = result.Replace("[#as]", string.Format(" as {0}", CommonMethods.CombineFieldPrefix(alias)));
            return result;
        }
        /// <summary>
        /// 获取表语法
        /// </summary>
        /// <param name="alias">表别名</param>
        /// <returns>表语法</returns>
        public static string GetFrom()
        {
            string result = string.Format("{0} ", TableStructM.Info_ProjectTeam.TABLENAME);
            return result;
        }
        /// <summary>
        /// 读取数据库
        /// </summary>
        /// <param name="alias">表别名</param>
        /// <param name="connection">链接类</param>
        /// <param name="top">指定笔数</param>
        /// <param name="condition">其他条件（需带入and）</param>
        /// <returns>数据</returns>
        public static List<ProjectsTeamM> ReadDataBase(string condition , IConnectionD connection, int top = 0, string alias = "")
        {
            List<ProjectsTeamM> result = null;

            string strTop = "";
            if (top != 0) strTop = string.Format("top {0}", top);
            string fields = GetField(alias);
            string from = GetFrom();
            string where = string.Format("where 1=1");
            if (!string.IsNullOrEmpty(condition)) where = string.Format("{0} {1}", where, condition);
            string orderby = string.Format("order by {0}", TableStructM.Info_ProjectTeam.PT_ID);
            string sql = string.Format("select {0} {1} from {2} {3} {4}", strTop, fields, from, where, orderby);
            connection.DataBaseFactory.GetDataReader(sql);

            if (connection.DataBaseFactory.IsEffect()) result = AddDataToList(connection.DataBaseFactory.Reader);

            connection.DataBaseFactory.CloseDataReader();
            return result;
        }

        /// <summary>
        /// 读取数据库
        /// </summary>
        /// <param name="condition">其他条件（需带入and）</param>
        /// <param name="connection">链接类</param>
        /// <returns>数据</returns>
        //public static List<ProjectsM> ReadDataBase(string condition = "", IConnectionD connection = null)
        public static List<ProjectsTeamM> ReadDataBase(IConnectionD connection = null)
        {
            List<ProjectsTeamM> result = null;

            string fields = GetField();
            string from = GetFrom();
            string where = string.Format("where 1=1");
            //if (!string.IsNullOrEmpty(condition)) where = string.Format("{0} {1}", where, condition);
            string sql = string.Format("select {0} from {1} {2} ", fields, from, where);
            connection.DataBaseFactory.GetDataReader(sql);

            if (connection.DataBaseFactory.IsEffect()) result = AddDataToList(connection.DataBaseFactory.Reader);

            connection.DataBaseFactory.CloseDataReader();
            return result;
        }
        /// <summary>
        /// 将数据添加到链表中
        /// </summary>
        /// <param name="dr">数据阅读器</param>
        /// <param name="alias">表别名</param>
        /// <returns>链表</returns>
        public static List<ProjectsTeamM> AddDataToList(IDataReader dr)
        {
            List<ProjectsTeamM> result = new List<ProjectsTeamM>();

            while (dr.Read())
            {
                result.Add(AddDataToObject(dr));
            }

            return result;
        }
        /// <summary>
        /// 将数据阅读器中的数据添加到对象中
        /// </summary>
        /// <param name="dr">数据阅读器</param>
        /// <param name="alias">表别名</param>
        /// <returns>数据</returns>
        public static ProjectsTeamM AddDataToObject(IDataReader dr, string alias = "")
        {
            ProjectsTeamM result = new ProjectsTeamM();

            result.PTID = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_ProjectTeam.PT_ID, alias)].ConvertToInt32();
            result.PTName = (dr[CommonMethods.CombineFieldAlias(TableStructM.Info_ProjectTeam.PT_NAME, alias)].ToString());
            // result.SetOnOff(dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_ONOFF, alias)].ConvertToInt32());

            return result;
        }
        /// <summary>
        /// 将数据行中的数据添加到对象中
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="alias">表别名</param>
        /// <returns>数据</returns>
        public static ProjectsTeamM AddDataToObject(DataRow row, string alias)
        {
            ProjectsTeamM result = new ProjectsTeamM();

            result.PTID = row[CommonMethods.CombineFieldAlias(TableStructM.Info_ProjectTeam.PT_ID, alias)].ConvertToInt32();
            result.PTName = (row[CommonMethods.CombineFieldAlias(TableStructM.Info_ProjectTeam.PT_NAME, alias)].ToString());
            // result.SetOnOff(row[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_ONOFF, alias)].ConvertToInt32());

            return result;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="connection">链接类</param>
        /// <returns>数据</returns>
        public static List<ProjectsTeamM> GetDataProjectsTeam(IConnectionD connection)
        {
            //const string ALIAS_Projects = "a";
            return ReadDataBase(connection);
            //return ReadDataBase(ALIAS_Projects, connection);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="start">起始数据</param>
        /// <param name="size">显示笔数</param>
        /// <param name="alias">表别名</param>
        /// <param name="alias_group">alias_group表别名</param>
        /// <param name="connection">链接类</param>
        /// <param name="condition">其他条件（需带入and）</param>
        /// <param name="order">排序条件（无需带入order by）</param>
        /// <returns></returns>
        public static List<ProjectsTeamM> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, string belong, IConnectionD connection)
        {
            string where = "", orderby = "";
            if (!string.IsNullOrEmpty(key)) where = string.Format("{0} and({1} like '%{2}%')", where, TableStructM.Info_ProjectTeam.PT_NAME, key.ReplaceStr());
            if (!string.IsNullOrEmpty(order)) orderby = string.Format("{0} {1}", order, (orderway == OrderType.otAsc ? "asc" : "desc"));
          
            string condition = GetFrom();
            count = connection.DataBaseFactory.GetCount(TableStructM.Info_ProjectTeam.TABLENAME, string.Format("where 1=1 {0}", where));

            return ReadPageDataBase(start, size, where, orderby, connection);

        }

        /// <summary>
        /// 读取数据库
        /// </summary>
        /// <param name="condition">其他条件（需带入and）</param>
        /// <param name="start">起始数据</param>
        /// <param name="size">显示笔数</param>
        /// <param name="order">排序条件（无需带入order by）</param>
        /// <param name="connection">链接类</param>
        /// <returns>数据</returns>
        public static List<ProjectsTeamM> ReadPageDataBase(long start, int size, string condition = "", string order = "", IConnectionD connection = null)
        {
            List<ProjectsTeamM> result = null;
            string tablename = TableStructM.Info_ProjectTeam.TABLENAME;
            string fields = GetField();
            string from = GetFrom();
            string orderby = string.Format("order by {0}", order);
            string condition_where = string.Format("where 1=1");
            string where = string.Format("where {0} not in (select top {1} {0} from {2} {3}{4}{5})", TableStructM.Info_ProjectTeam.PT_ID, start, from, condition_where, condition, orderby);
            if (!string.IsNullOrEmpty(condition)) where = string.Format("{0} {1}", where, condition);
            string sql = string.Format("select top {0} {1} from {2} {3} {4}", size, fields, from, where, orderby);
            connection.DataBaseFactory.GetDataReader(sql);

            if (connection.DataBaseFactory.IsEffect()) result = AddDataToList(connection.DataBaseFactory.Reader);

            connection.DataBaseFactory.CloseDataReader();
            return result;
        }
        /// <summary>
        /// 判断项目是否存在
        /// </summary>
        /// <param name="projectsnname">项目名</param>
        /// <param name="connection">链接类</param>
        /// <returns>项目类</returns>
        public static ProjectsTeamM IsExist_projectsteamname(string projectsteamname, IConnectionD connection)
        {
            ProjectsTeamM result = null;

            string where = string.Format(" and {0}='{1}'", TableStructM.Info_ProjectTeam.PT_NAME, projectsteamname.ReplaceStr());
            IList<ProjectsTeamM> lst = ReadDataBase(where, connection);
            if (lst != null) result = lst.FirstOrDefault();
            return result;
        }
        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="userm">项目信息类（模型层）</param>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            string fields = string.Format("{0}", TableStructM.Info_ProjectTeam.PT_NAME);
            string values = string.Format("{0}", "@pt_name");
           
            List<IDataParameter> lstParam = new List<IDataParameter>();
            _dbfactory.AddParameter(lstParam, "@pr_name", this._projectsteamm.PTName);
            int effect = this._dbfactory.Insert(TableStructM.Info_ProjectTeam.TABLENAME, fields, values, lstParam);

            return (effect > 0);
        }

        /// <summary>
        /// 删除项目信息
        /// </summary>
        /// <param name="projectsnm">项目信息模型类（模型层）</param>
        /// <returns>受影响的行数</returns>
        public int Del_ProjectsTeam()
        {
            string where = string.Format("where {0}=@id", TableStructM.Info_ProjectTeam.PT_ID);
            List<IDataParameter> lstParam = new List<IDataParameter>();
            this._dbfactory.AddParameter(lstParam, "@id", this._projectsteamm.PTID);
            return this._dbfactory.Delete(TableStructM.Info_ProjectTeam.TABLENAME, where, lstParam);

        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="connection">链接类</param>
        /// <returns>数据</returns>
        public static ProjectsTeamM GetDataByID(string id, IConnectionD connection)
        {
            string where = string.Format(" and {0}={1}", TableStructM.Info_ProjectTeam.PT_ID, id);
            IList<ProjectsTeamM> lst = ReadDataBase(where,connection);
            return (lst != null && lst.Count > 0 ? lst.FirstOrDefault() : null);
        }

        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Update()
        {
            string updates = @"#pt_name=@pt_name";
            string where = string.Format("where #pt_id=@id");
            List<IDataParameter> lstParam = new List<IDataParameter>();
            updates = updates.Replace("#pr_name", TableStructM.Info_ProjectTeam.PT_NAME);
            this._dbfactory.AddParameter(lstParam, "@pt_name", this._projectsteamm.PTName);
            updates = updates.Replace("#pr_belong", TableStructM.Info_Projects.PR_BELONG);
            this._dbfactory.AddParameter(lstParam, "@id", this._projectsteamm.PTID);
            return this._dbfactory.Update(TableStructM.Info_ProjectTeam.TABLENAME, updates, where, lstParam);
        }
        #endregion
    }
}
