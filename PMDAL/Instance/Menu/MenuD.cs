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
    /// 后台菜单信息类（数据链路层）
    /// </summary>
    public class MenuD : IMenuD
    {
        #region 变量
        private DbFactoryD _dbfactory;                          //数据库工厂类
        private MenuM _menum;                                   //后台菜单信息类（模型层）
        #endregion
        #region 属性
        /// <summary>
        /// 后台菜单信息类（模型层）
        /// </summary>
        public MenuM Infomation_menu
        {
            set { this._menum = value; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectiond">链接类</param>
        public MenuD(IConnectionD connectiond)
        {
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
            string result = string.Format("[#alias]{0}[#as]{0}, [#alias]{1}[#as]{1}, [#alias]{2}[#as]{2}, [#alias]{3}[#as]{3}, [#alias]{4}[#as]{4}, [#alias]{5}[#as]{5}, [#alias]{6}[#as]{6}, [#alias]{7}[#as]{7}",
                TableStructM.Info_Menu.MN_ID, TableStructM.Info_Menu.MN_TID, TableStructM.Info_Menu.MN_PID, TableStructM.Info_Menu.MN_NAME, TableStructM.Info_Menu.MN_LINK,
                TableStructM.Info_Menu.MN_ORDER, TableStructM.Info_Menu.MN_LEVEL, TableStructM.Info_Menu.MN_ONOFF);
            result = result.Replace("[#alias]", (string.IsNullOrEmpty(alias) ? "" : string.Format("{0}.", alias)));
            result = result.Replace("[#as]", string.Format(" as {0}", CommonMethods.CombineFieldPrefix(alias)));
            return result;
        }
        /// <summary>
        /// 获取表语法
        /// </summary>
        /// <param name="alias">表别名</param>
        /// <returns>表语法</returns>
        public static string GetFrom(string alias)
        {
            string result = string.Format("{0} {1}", TableStructM.Info_Menu.TABLENAME, alias);
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
        public static List<MenuM> ReadDataBase(string alias, IConnectionD connection, int top = 0, string condition = "")
        {
            List<MenuM> result = null;

            string strTop = "";
            if (top != 0) strTop = string.Format("top {0}", top);
            string fields = GetField(alias);
            string from = GetFrom(alias);
            string where = string.Format("where 1=1");
            if (!string.IsNullOrEmpty(condition)) where = string.Format("{0} {1}", where, condition);
            string orderby = string.Format("order by {0}", TableStructM.Info_Menu.MN_ID);
            string sql = string.Format("select {0} {1} from {2} {3} {4}", strTop, fields, from, where, orderby);
            connection.DataBaseFactory.GetDataReader(sql);

            if (connection.DataBaseFactory.IsEffect()) result = AddDataToList(connection.DataBaseFactory.Reader, alias);

            connection.DataBaseFactory.CloseDataReader();
            return result;
        }
        /// <summary>
        /// 将数据添加到链表中
        /// </summary>
        /// <param name="dr">数据阅读器</param>
        /// <param name="alias">表别名</param>
        /// <returns>链表</returns>
        public static List<MenuM> AddDataToList(IDataReader dr, string alias)
        {
            List<MenuM> result = new List<MenuM>();

            while (dr.Read())
            {
                result.Add(AddDataToObject(dr, alias));
            }

            return result;
        }
        /// <summary>
        /// 将数据阅读器中的数据添加到对象中
        /// </summary>
        /// <param name="dr">数据阅读器</param>
        /// <param name="alias">表别名</param>
        /// <returns>数据</returns>
        public static MenuM AddDataToObject(IDataReader dr, string alias)
        {
            MenuM result = new MenuM();

            result.MNID = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_ID, alias)].ConvertToInt32();
            result.MNTID = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_TID, alias)].ConvertToInt32();
            result.MNPID = (dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_PID, alias)].ConvertToInt32());
            result.Name = (dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_NAME, alias)].ToString());
            result.Link = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_LINK, alias)].ToString();
            result.Order = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_ORDER, alias)].ConvertToInt32();
            result.Level = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_LEVEL, alias)].ConvertToInt32();
           // result.SetOnOff(dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_ONOFF, alias)].ConvertToInt32());
            
            return result;
        }
        /// <summary>
        /// 将数据行中的数据添加到对象中
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="alias">表别名</param>
        /// <returns>数据</returns>
        public static MenuM AddDataToObject(DataRow row, string alias)
        {
            MenuM result = new MenuM();

            result.MNID = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_ID, alias)].ConvertToInt32();
            result.MNTID = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_TID, alias)].ConvertToInt32();
            result.MNPID = (row[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_PID, alias)].ConvertToInt32());
            result.Name = (row[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_NAME, alias)].ToString());
            result.Link = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_LINK, alias)].ToString();
            result.Order = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_ORDER, alias)].ConvertToInt32();
            result.Level = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_LEVEL, alias)].ConvertToInt32();
           // result.SetOnOff(row[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_ONOFF, alias)].ConvertToInt32());
           
            return result;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="connection">链接类</param>
        /// <returns>数据</returns>
        public static List<MenuM> GetDataMenu(IConnectionD connection)
        {
            const string ALIAS_MENU = "a";

            return ReadDataBase(ALIAS_MENU, connection);
        }
        #endregion
    }
}
