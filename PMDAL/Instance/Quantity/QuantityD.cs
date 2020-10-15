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
    /// 工程量信息类（数据链路层）
    /// </summary>
    public class QuantityD : IQuantityD
    {
        #region 变量
        private DbFactoryD _dbfactory;                          //数据库工厂类
        private QuantityM _quantitym;                          //工程量信息类（模型层）
        private IConnectionD _connectiond;                      //链接类
        #endregion
        #region 属性
        /// <summary>
        /// 工程量信息类（模型层）
        /// </summary>
        public QuantityM Infomation_Quantity
        {
            set { this._quantitym = value; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectiond">链接类</param>
        public QuantityD(IConnectionD connectiond)
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
            string result = string.Format("[#alias]{0}[#as]{0}, [#alias]{1}[#as]{1}, [#alias]{2}[#as]{2}, [#alias]{3}[#as]{3}, [#alias]{4}[#as]{4}, [#alias]{5}[#as]{5}, [#alias]{6}[#as]{6}, [#alias]{7}[#as]{7}, [#alias]{8}[#as]{8}",
                TableStructM.Info_Quantity.QT_ID, TableStructM.Info_Quantity.QT_PRID, TableStructM.Info_Quantity.QT_CNID, TableStructM.Info_Quantity.QT_CLID, TableStructM.Info_Quantity.QT_CONTENT, TableStructM.Info_Quantity.QT_MEASUREMENT, TableStructM.Info_Quantity.QT_QUANTITY, TableStructM.Info_Quantity.QT_PRICE, TableStructM.Info_Quantity.QT_MONEY);
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
            string result = string.Format("{0} ", TableStructM.Info_Quantity.TABLENAME);
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
        public static List<QuantityM> ReadDataBase(string alias, IConnectionD connection, int top = 0, string condition = "")
        {
            List<QuantityM> result = null;

            string strTop = "";
            if (top != 0) strTop = string.Format("top {0}", top);
            string fields = GetField(alias);
            string from = GetFrom();
            string where = string.Format("where 1=1");
            if (!string.IsNullOrEmpty(condition)) where = string.Format("{0} {1}", where, condition);
            string orderby = string.Format("order by {0}", TableStructM.Info_Quantity.QT_ID);
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
        public static List<QuantityM> ReadDataBase(string condition = "", IConnectionD connection = null)
        {
            List<QuantityM> result = null;

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
        public static List<QuantityM> AddDataToList(IDataReader dr)
        {
            List<QuantityM> result = new List<QuantityM>();

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
        public static QuantityM AddDataToObject(IDataReader dr, string alias = "")
        {
            QuantityM result = new QuantityM();

            result.QTID = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_ID, alias)].ConvertToInt32();
            result.QTPRID = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_PRID, alias)].ConvertToInt32();
            result.QTCNID = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_CNID, alias)].ConvertToInt32();
            result.QTCLID = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_CLID, alias)].ConvertToInt32();
            result.QTCONTENT = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_CONTENT, alias)].ToString();
            result.QTQUANTITY = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_QUANTITY, alias)].ConvertToDecimal();
            result.QTMEASUREMENT = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_MEASUREMENT, alias)].ToString();
            result.QTPRICE = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_PRICE, alias)].ConvertToDecimal();
            result.QTMONEY = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_MONEY, alias)].ConvertToDecimal();
            return result;
        }
        /// <summary>
        /// 将数据行中的数据添加到对象中
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="alias">表别名</param>
        /// <returns>数据</returns>
        public static QuantityM AddDataToObject(DataRow row, string alias)
        {
            QuantityM result = new QuantityM();

            result.QTID = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_ID, alias)].ConvertToInt32();
            result.QTPRID = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_PRID, alias)].ConvertToInt32();
            result.QTCNID = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_CNID, alias)].ConvertToInt32();
            result.QTCLID = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_CLID, alias)].ConvertToInt32();
            result.QTCONTENT = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_CONTENT, alias)].ToString();
            result.QTQUANTITY = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_QUANTITY, alias)].ConvertToDecimal();
            result.QTMEASUREMENT = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_MEASUREMENT, alias)].ToString();
            result.QTPRICE = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_PRICE, alias)].ConvertToDecimal();
            result.QTMONEY = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Quantity.QT_MONEY, alias)].ConvertToDecimal();
            // result.SetOnOff(row[CommonMethods.CombineFieldAlias(TableStructM.Info_Menu.MN_ONOFF, alias)].ConvertToInt32());

            return result;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="connection">链接类</param>
        /// <returns>数据</returns>
        public static List<QuantityM> GetDataFinance(IConnectionD connection)
        {
            const string ALIAS_Quantity = "a";

            return ReadDataBase(ALIAS_Quantity, connection);
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
        public static List<QuantityM> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, IConnectionD connection)
        {
            string where = "", orderby = "";
            string alias = "a";
           
            if (!string.IsNullOrEmpty(order)) orderby = string.Format("{0} {1}", order, (orderway == OrderType.otAsc ? "asc" : "desc"));
                      
            string condition = GetFrom();
            count = connection.DataBaseFactory.GetCount(TableStructM.Info_Quantity.TABLENAME, string.Format("where 1=1 {0}", where));

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
        public static List<QuantityM> ReadPageDataBase(long start, int size, string condition = "", string order = "", IConnectionD connection = null)
        {
            List<QuantityM> result = null;
            string tablename = TableStructM.Info_Quantity.TABLENAME;
            string fields = GetField();
            string from = GetFrom();
            string orderby = string.Format("order by {0}", order);
            string condition_where = string.Format("where 1=1");
            string where = string.Format("where {0} not in (select top {1} {0} from {2} {3}{4}{5})", TableStructM.Info_Quantity.QT_ID, start, from, condition_where, condition, orderby);
            if (!string.IsNullOrEmpty(condition)) where = string.Format("{0} {1}", where, condition);
            string sql = string.Format("select top {0} {1} from {2} {3} {4}", size, fields, from, where, orderby);
            connection.DataBaseFactory.GetDataReader(sql);

            if (connection.DataBaseFactory.IsEffect()) result = AddDataToList(connection.DataBaseFactory.Reader);

            connection.DataBaseFactory.CloseDataReader();
            return result;
        }
        /// <summary>
        /// 判断工程量是否存在
        /// </summary>
        /// <param name="financenname">工程量名</param>
        /// <param name="connection">链接类</param>
        /// <returns>收付款类</returns>
        public static QuantityM IsExist_financename(string quantityname, IConnectionD connection)
        {
            QuantityM result = null;

            string where = string.Format(" and {0}='{1}'", TableStructM.Info_Quantity.QT_ID, quantityname.ReplaceStr());
            IList<QuantityM> lst = ReadDataBase(where, connection);
            if (lst != null) result = lst.FirstOrDefault();
            return result;
        }
        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="userm">工程量信息类（模型层）</param>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            string fields = string.Format("{0},{1},{2},{3},{4},{5}, {6}, {7}", TableStructM.Info_Quantity.QT_PRID, TableStructM.Info_Quantity.QT_CNID, TableStructM.Info_Quantity.QT_CLID, TableStructM.Info_Quantity.QT_CONTENT, TableStructM.Info_Quantity.QT_QUANTITY, TableStructM.Info_Quantity.QT_MEASUREMENT, TableStructM.Info_Quantity.QT_PRICE, TableStructM.Info_Quantity.QT_MONEY);
            string values = string.Format("{0},{1},{2},{3},{4},{5}, {6}, {7}", "@qt_prid", "@qt_cnid", "@qt_clid", "@qt_content", "@qt_quantity", "@qt_measurement", "@qt_price", "@qt_money");
           
            List<IDataParameter> lstParam = new List<IDataParameter>();
            _dbfactory.AddParameter(lstParam, "@qt_prid", this._quantitym.QTPRID);
            _dbfactory.AddParameter(lstParam, "@qt_cnid", this._quantitym.QTCNID);
            _dbfactory.AddParameter(lstParam, "@qt_clid", this._quantitym.QTCLID);
            _dbfactory.AddParameter(lstParam, "@qt_content", this._quantitym.QTCONTENT);
            _dbfactory.AddParameter(lstParam, "@qt_quantity", this._quantitym.QTQUANTITY);
            _dbfactory.AddParameter(lstParam, "@qt_measurement", this._quantitym.QTMEASUREMENT);
            _dbfactory.AddParameter(lstParam, "@qt_price", this._quantitym.QTPRICE);
            _dbfactory.AddParameter(lstParam, "@qt_money", this._quantitym.QTMONEY);
            int effect = this._dbfactory.Insert(TableStructM.Info_Quantity.TABLENAME, fields, values, lstParam);

            return (effect > 0);
        }

        /// <summary>
        /// 删除工程量信息
        /// </summary>
        /// <param name="financenm">工程量信息模型类（模型层）</param>
        /// <returns>受影响的行数</returns>
        public int Del_Quantity()
        {
            string where = string.Format("where {0}=@id", TableStructM.Info_Quantity.QT_ID);
            List<IDataParameter> lstParam = new List<IDataParameter>();
            this._dbfactory.AddParameter(lstParam, "@id", this._quantitym.QTID);
            return this._dbfactory.Delete(TableStructM.Info_Quantity.TABLENAME, where, lstParam);

        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="connection">链接类</param>
        /// <returns>数据</returns>
        public static QuantityM GetDataByID(string id, IConnectionD connection)
        {
            string where = string.Format(" and {0}={1}", TableStructM.Info_Quantity.QT_ID, id);
            IList<QuantityM> lst = ReadDataBase(where, connection);
            return (lst != null && lst.Count > 0 ? lst.FirstOrDefault() : null);
        }

        /// <summary>
        /// 更新工程量信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Update()
        {
            string updates = @"#qt_prid=@qt_prid,#qt_cnid=@qt_cnid,#qt_clid=@qt_clid,#qt_content=@qt_content,#qt_measurement=@qt_measurement,#qt_quantity=@qt_quantity,#qt_price=@qt_price,#qt_money=@qt_money";
            string where = string.Format("where #qt_id=@id");
            List<IDataParameter> lstParam = new List<IDataParameter>();
            updates = updates.Replace("#qt_prid", TableStructM.Info_Quantity.QT_PRID);
            this._dbfactory.AddParameter(lstParam, "@qt_prid", this._quantitym.QTPRID);
            updates = updates.Replace("#qt_cnid", TableStructM.Info_Quantity.QT_CNID);
            this._dbfactory.AddParameter(lstParam, "@qt_cnid", this._quantitym.QTCNID);
            updates = updates.Replace("#qt_clid", TableStructM.Info_Quantity.QT_CLID);
            this._dbfactory.AddParameter(lstParam, "@qt_clid", this._quantitym.QTCLID);
            updates = updates.Replace("#qt_content", TableStructM.Info_Quantity.QT_CONTENT);
            this._dbfactory.AddParameter(lstParam, "@qt_content", this._quantitym.QTCONTENT);
            updates = updates.Replace("#qt_measurement", TableStructM.Info_Quantity.QT_MEASUREMENT);
            this._dbfactory.AddParameter(lstParam, "@qt_measurement", this._quantitym.QTMEASUREMENT);
            updates = updates.Replace("#qt_quantiry", TableStructM.Info_Quantity.QT_QUANTITY);
            this._dbfactory.AddParameter(lstParam, "@qt_quantity", this._quantitym.QTQUANTITY);
            updates = updates.Replace("#qt_price", TableStructM.Info_Quantity.QT_PRICE);
            this._dbfactory.AddParameter(lstParam, "@qt_price", this._quantitym.QTPRICE);
            updates = updates.Replace("#qt_money", TableStructM.Info_Quantity.QT_MONEY);
            this._dbfactory.AddParameter(lstParam, "@qt_money", this._quantitym.QTMONEY);

            where = where.Replace("#qt_id", TableStructM.Info_Quantity.QT_ID);
            this._dbfactory.AddParameter(lstParam, "@id", this._quantitym.QTID);
            return this._dbfactory.Update(TableStructM.Info_Quantity.TABLENAME, updates, where, lstParam);
        }
        #endregion
    }
}
