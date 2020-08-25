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
    /// 供应商信息类（数据链路层）
    /// </summary>
    public class SuppliersD : ISuppliersD
    {
        #region 变量
        private DbFactoryD _dbfactory;                          //数据库工厂类
        private SuppliersM _suppliersm;                                   //供应商信息类（模型层）
        private IConnectionD _connectiond;                      //链接类
        #endregion
        #region 属性
        /// <summary>
        /// 供应商信息类（模型层）
        /// </summary>
        public SuppliersM Infomation_suppliers
        {
            set { this._suppliersm = value; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectiond">链接类</param>
        public SuppliersD(IConnectionD connectiond)
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
                TableStructM.Info_Suppliers.OW_ID, TableStructM.Info_Suppliers.OW_NAME);
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
            string result = string.Format("{0} ", TableStructM.Info_Suppliers.TABLENAME);
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
        public static List<SuppliersM> ReadDataBase(string alias, IConnectionD connection, int top = 0, string condition = "")
        {
            List<SuppliersM> result = null;

            string strTop = "";
            if (top != 0) strTop = string.Format("top {0}", top);
            string fields = GetField(alias);
            string from = GetFrom();
            string where = string.Format("where 1=1");
            if (!string.IsNullOrEmpty(condition)) where = string.Format("{0} {1}", where, condition);
            string orderby = string.Format("order by {0}", TableStructM.Info_Suppliers.OW_ID);
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
        public static List<SuppliersM> ReadDataBase(string condition = "", IConnectionD connection = null)
        {
            List<SuppliersM> result = null;

            string fields = GetField();
            string from = GetFrom();
            string where = string.Format("where 1=1");
            if (!string.IsNullOrEmpty(condition)) where = string.Format("{0} {1}", where, condition);
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
        public static List<SuppliersM> AddDataToList(IDataReader dr)
        {
            List<SuppliersM> result = new List<SuppliersM>();

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
        public static SuppliersM AddDataToObject(IDataReader dr, string alias = "")
        {
            SuppliersM result = new SuppliersM();

            result.OWID = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Suppliers.OW_ID, alias)].ConvertToInt32();
            result.Name = (dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Suppliers.OW_NAME, alias)].ToString());
            // result.SetOnOff(dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_ONOFF, alias)].ConvertToInt32());

            return result;
        }
        /// <summary>
        /// 将数据行中的数据添加到对象中
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="alias">表别名</param>
        /// <returns>数据</returns>
        public static SuppliersM AddDataToObject(DataRow row, string alias)
        {
            SuppliersM result = new SuppliersM();

            result.OWID = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Suppliers.OW_ID, alias)].ConvertToInt32();
            result.Name = (row[CommonMethods.CombineFieldAlias(TableStructM.Info_Suppliers.OW_NAME, alias)].ToString());
            // result.SetOnOff(row[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_ONOFF, alias)].ConvertToInt32());

            return result;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="connection">链接类</param>
        /// <returns>数据</returns>
        public static List<SuppliersM> GetDataSuppliers(IConnectionD connection)
        {
            const string ALIAS_Suppliers = "a";

            return ReadDataBase(ALIAS_Suppliers, connection);
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
        public static List<SuppliersM> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, IConnectionD connection)
        {
            string where = "", orderby = "";
            string alias = "a";
            if (!string.IsNullOrEmpty(key)) where = string.Format("{0} and({1} like '%{2}%')", where, TableStructM.Info_Suppliers.OW_NAME, key.ReplaceStr());
            if (!string.IsNullOrEmpty(order)) orderby = string.Format("{0} {1}", order, (orderway == OrderType.otAsc ? "asc" : "desc"));
            string condition = GetFrom();
            count = connection.DataBaseFactory.GetCount(TableStructM.Info_Suppliers.TABLENAME, string.Format("where 1=1 {0}", where));

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
        public static List<SuppliersM> ReadPageDataBase(long start, int size, string condition = "", string order = "", IConnectionD connection = null)
        {
            List<SuppliersM> result = null;
            string tablename = TableStructM.Info_Suppliers.TABLENAME;
            string fields = GetField();
            string from = GetFrom();
            string orderby = string.Format("order by {0}", order);
            string condition_where = string.Format("where 1=1");
            string where = string.Format("where {0} not in (select top {1} {0} from {2} {3}{4}{5})", TableStructM.Info_Suppliers.OW_ID, start, from, condition_where, condition, orderby);
            if (!string.IsNullOrEmpty(condition)) where = string.Format("{0} {1}", where, condition);
            string sql = string.Format("select top {0} {1} from {2} {3} {4}", size, fields, from, where, orderby);
            connection.DataBaseFactory.GetDataReader(sql);

            if (connection.DataBaseFactory.IsEffect()) result = AddDataToList(connection.DataBaseFactory.Reader);

            connection.DataBaseFactory.CloseDataReader();
            return result;
        }
        /// <summary>
        /// 判断供应商是否存在
        /// </summary>
        /// <param name="suppliersname">供应商名</param>
        /// <param name="connection">链接类</param>
        /// <returns>供应商类</returns>
        public static SuppliersM IsExist_suppliersname(string suppliersname, IConnectionD connection)
        {
            SuppliersM result = null;

            string where = string.Format(" and {0}='{1}'", TableStructM.Info_Suppliers.OW_NAME, suppliersname.ReplaceStr());
            IList<SuppliersM> lst = ReadDataBase(where, connection);
            if (lst != null) result = lst.FirstOrDefault();
            return result;
        }
        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="userm">供应商信息类（模型层）</param>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            string fields = string.Format("{0}", TableStructM.Info_Suppliers.OW_NAME);
            string values = string.Format("{0}", "@ow_name");
            List<IDataParameter> lstParam = new List<IDataParameter>();
            _dbfactory.AddParameter(lstParam, "@ow_name", this._suppliersm.Name);
            int effect = this._dbfactory.Insert(TableStructM.Info_Suppliers.TABLENAME, fields, values, lstParam);

            return (effect > 0);
        }

        /// <summary>
        /// 删除供应商信息
        /// </summary>
        /// <param name="suppliersm">供应商信息模型类（模型层）</param>
        /// <returns>受影响的行数</returns>
        public int Del_Suppliers()
        {
            string where = string.Format("where {0}=@id", TableStructM.Info_Suppliers.OW_ID);
            List<IDataParameter> lstParam = new List<IDataParameter>();
            this._dbfactory.AddParameter(lstParam, "@id", this._suppliersm.OWID);
            return this._dbfactory.Delete(TableStructM.Info_Suppliers.TABLENAME, where, lstParam);

        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="connection">链接类</param>
        /// <returns>数据</returns>
        public static SuppliersM GetDataByID(string id, IConnectionD connection)
        {
            string where = string.Format(" and {0}={1}", TableStructM.Info_Suppliers.OW_ID, id);
            IList<SuppliersM> lst = ReadDataBase(where, connection);
            return (lst != null && lst.Count > 0 ? lst.FirstOrDefault() : null);
        }

        /// <summary>
        /// 更新供应商信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Update()
        {
            string updates = @"#ow_name=@ow_name";
            string where = string.Format("where #ow_id=@id");
            List<IDataParameter> lstParam = new List<IDataParameter>();
            updates = updates.Replace("#ow_name", TableStructM.Info_Suppliers.OW_NAME);
            this._dbfactory.AddParameter(lstParam, "@ow_name", this._suppliersm.Name);
            where = where.Replace("#ow_id", TableStructM.Info_Suppliers.OW_ID);
            this._dbfactory.AddParameter(lstParam, "@id", this._suppliersm.OWID);
            return this._dbfactory.Update(TableStructM.Info_Suppliers.TABLENAME, updates, where, lstParam);
        }
        #endregion
    }
}
