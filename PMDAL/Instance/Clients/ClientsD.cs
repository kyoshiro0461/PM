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
    /// 客户信息类（数据链路层）
    /// </summary>
    public class ClientsD : IClientsD
    {
        #region 变量
        private DbFactoryD _dbfactory;                          //数据库工厂类
        private ClientsM _clientsm;                             //客户信息类（模型层）
        private IConnectionD _connectiond;                      //链接类
        #endregion
        #region 属性
        /// <summary>
        /// 客户信息类（模型层）
        /// </summary>
        public ClientsM Infomation_clients
        {
            set { this._clientsm = value; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectiond">链接类</param>
        public ClientsD(IConnectionD connectiond)
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
                TableStructM.Info_Clients.CL_ACCOUNT,TableStructM.Info_Clients.CL_ADDRESS,TableStructM.Info_Clients.CL_BANK,TableStructM.Info_Clients.CL_BELONG,TableStructM.Info_Clients.CL_CODE,TableStructM.Info_Clients.CL_ID,TableStructM.Info_Clients.CL_NAME,TableStructM.Info_Clients.CL_PERSON,TableStructM.Info_Clients.CL_TEL);
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
            string result = string.Format("{0} ", TableStructM.Info_Clients.TABLENAME);
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
        public static List<ClientsM> ReadDataBase(string alias, IConnectionD connection, int top = 0, string condition = "")
        {
            List<ClientsM> result = null;
            string strTop = "";
            if (top != 0) strTop = string.Format("top {0}", top);
            string fields = GetField(alias);
            string from = GetFrom();
            string where = string.Format("where 1=1");
            if (!string.IsNullOrEmpty(condition)) where = string.Format("{0} {1}", where, condition);
            string orderby = string.Format("order by {0}", TableStructM.Info_Clients.CL_ID);
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
        public static List<ClientsM> ReadDataBase(string condition = "", IConnectionD connection = null)
        {
            List<ClientsM> result = null;

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
        public static List<ClientsM> AddDataToList(IDataReader dr)
        {
            List<ClientsM> result = new List<ClientsM>();

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
        public static ClientsM AddDataToObject(IDataReader dr, string alias = "")
        {
            ClientsM result = new ClientsM();

            result.CLID = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_ID, alias)].ConvertToInt32();
            result.CLNAME = (dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_NAME, alias)].ToString());
            result.CLACCOUNT = (dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_ACCOUNT, alias)].ToString());
            result.CLADDRESS = (dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_ADDRESS, alias)].ToString());
            result.CLBANK = (dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_BANK, alias)].ToString());
            result.CLBELONG = dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_BELONG, alias)].ConvertToInt32();
            result.CLCODE = (dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_CODE, alias)].ToString());
            result.CLPERSON = (dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_PERSON, alias)].ToString());
            result.CLTEL = (dr[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_TEL, alias)].ToString());
            return result;
        }
        /// <summary>
        /// 将数据行中的数据添加到对象中
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="alias">表别名</param>
        /// <returns>数据</returns>
        public static ClientsM AddDataToObject(DataRow row, string alias)
        {
            ClientsM result = new ClientsM();


            result.CLID = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_ID, alias)].ConvertToInt32();
            result.CLNAME = (row[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_NAME, alias)].ToString());
            result.CLACCOUNT = (row[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_ACCOUNT, alias)].ToString());
            result.CLADDRESS = (row[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_ADDRESS, alias)].ToString());
            result.CLBANK = (row[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_BANK, alias)].ToString());
            result.CLBELONG = row[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_BELONG, alias)].ConvertToInt32();
            result.CLCODE = (row[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_CODE, alias)].ToString());
            result.CLPERSON = (row[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_PERSON, alias)].ToString());
            result.CLTEL = (row[CommonMethods.CombineFieldAlias(TableStructM.Info_Clients.CL_TEL, alias)].ToString());
            return result;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="connection">链接类</param>
        /// <returns>数据</returns>
        public static List<ClientsM> GetDataOwer(IConnectionD connection)
        {
            const string ALIAS_Clients = "a";

            return ReadDataBase(ALIAS_Clients, connection);
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
        public static List<ClientsM> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, string belong, IConnectionD connection)
        {
            string where = "", orderby = "";
            string alias = "a";
            if (!string.IsNullOrEmpty(key)) where = string.Format("{0} and({1} like '%{2}%')", where, TableStructM.Info_Clients.CL_NAME, key.ReplaceStr());
            if (!string.IsNullOrEmpty(order)) orderby = string.Format("{0} {1}", order, (orderway == OrderType.otAsc ? "asc" : "desc"));
            if (!string.IsNullOrEmpty(belong)) where = string.Format("{0} and {1} ={2}", where, TableStructM.Info_Clients.CL_BELONG, belong.ReplaceStr());
            string condition = GetFrom();
            count = connection.DataBaseFactory.GetCount(TableStructM.Info_Clients.TABLENAME, string.Format("where 1=1 {0}", where));

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
        public static List<ClientsM> ReadPageDataBase(long start, int size, string condition = "", string order = "", IConnectionD connection = null)
        {
            List<ClientsM> result = null;
            string tablename = TableStructM.Info_Clients.TABLENAME;
            string fields = GetField();
            string from = GetFrom();
            string orderby = string.Format("order by {0}", order);
            string condition_where = string.Format("where 1=1");
            string where = string.Format("where {0} not in (select top {1} {0} from {2} {3}{4}{5})", TableStructM.Info_Clients.CL_ID, start, from, condition_where, condition, orderby);
            if (!string.IsNullOrEmpty(condition)) where = string.Format("{0} {1}", where, condition);
            string sql = string.Format("select top {0} {1} from {2} {3} {4}", size, fields, from, where, orderby);
            connection.DataBaseFactory.GetDataReader(sql);

            if (connection.DataBaseFactory.IsEffect()) result = AddDataToList(connection.DataBaseFactory.Reader);

            connection.DataBaseFactory.CloseDataReader();
            return result;
        }
        /// <summary>
        /// 判断客户是否存在
        /// </summary>
        /// <param name="clientsname">客户名称</param>
        /// <param name="connection">链接类</param>
        /// <returns>业主类</returns>
        public static ClientsM IsExist_clientsname(string clientsname, IConnectionD connection)
        {
            ClientsM result = null;

            string where = string.Format(" and {0}='{1}'", TableStructM.Info_Clients.CL_NAME, clientsname.ReplaceStr());
            IList<ClientsM> lst = ReadDataBase(where, connection);
            if (lst != null) result = lst.FirstOrDefault();
            return result;
        }
        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="clientsm">客户信息类（模型层）</param>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            string fields = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", TableStructM.Info_Clients.CL_ACCOUNT,TableStructM.Info_Clients.CL_ADDRESS,TableStructM.Info_Clients.CL_BANK,TableStructM.Info_Clients.CL_BELONG,TableStructM.Info_Clients.CL_CODE,TableStructM.Info_Clients.CL_NAME,TableStructM.Info_Clients.CL_PERSON,TableStructM.Info_Clients.CL_TEL);
            string values = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", "@cl_account","@cl_address","@cl_bank","@cl_belong","@cl_code","@cl_name","@cl_person","@cl_tel");
            List<IDataParameter> lstParam = new List<IDataParameter>();
            _dbfactory.AddParameter(lstParam, "@cl_account", this._clientsm.CLACCOUNT );
            _dbfactory.AddParameter(lstParam, "@cl_address", this._clientsm.CLADDRESS);
            _dbfactory.AddParameter(lstParam, "@cl_bank", this._clientsm.CLBANK);
            _dbfactory.AddParameter(lstParam, "@cl_belong", this._clientsm.CLBELONG);
            _dbfactory.AddParameter(lstParam, "@cl_code", this._clientsm.CLCODE);
            _dbfactory.AddParameter(lstParam, "@cl_name", this._clientsm.CLNAME);
            _dbfactory.AddParameter(lstParam, "@cl_person", this._clientsm.CLPERSON);
            _dbfactory.AddParameter(lstParam, "@cl_tel", this._clientsm.CLTEL);
            int effect = this._dbfactory.Insert(TableStructM.Info_Clients.TABLENAME, fields, values, lstParam);

            return (effect > 0);
        }

        /// <summary>
        /// 删除客户信息
        /// </summary>
        /// <param name="clientsm">客户信息模型类（模型层）</param>
        /// <returns>受影响的行数</returns>
        public int Del_Clients()
        {
            string where = string.Format("where {0}=@clid", TableStructM.Info_Clients.CL_ID);
            List<IDataParameter> lstParam = new List<IDataParameter>();
            this._dbfactory.AddParameter(lstParam, "@clid", this._clientsm.CLID);
            return this._dbfactory.Delete(TableStructM.Info_Clients.TABLENAME, where, lstParam);

        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="connection">链接类</param>
        /// <returns>数据</returns>
        public static ClientsM GetDataByID(string clid, IConnectionD connection)
        {
            string where = string.Format(" and {0}={1}", TableStructM.Info_Clients.CL_ID , clid);
            IList<ClientsM> lst = ReadDataBase(where, connection);
            return (lst != null && lst.Count > 0 ? lst.FirstOrDefault() : null);
        }

        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Update()
        {
            string updates = @"#cl_name=@cl_name,#cl_person=@cl_person,#cl_tel=@cl_tel,#cl_address=@cl_address,#cl_code=@cl_code,#cl_bank=@cl_bank,#cl_account=@cl_account,#cl_belong=@cl_belong";
            string where = string.Format("where #cl_id=@id");
            List<IDataParameter> lstParam = new List<IDataParameter>();
            updates = updates.Replace("#cl_name", TableStructM.Info_Clients.CL_NAME);
            this._dbfactory.AddParameter(lstParam, "@cl_name", this._clientsm.CLNAME);
            updates = updates.Replace("#cl_person", TableStructM.Info_Clients.CL_PERSON);
            this._dbfactory.AddParameter(lstParam, "@cl_person", this._clientsm.CLPERSON);
            updates = updates.Replace("#cl_tel", TableStructM.Info_Clients.CL_TEL);
            this._dbfactory.AddParameter(lstParam, "@cl_tel", this._clientsm.CLTEL);
            updates = updates.Replace("#cl_address", TableStructM.Info_Clients.CL_ADDRESS);
            this._dbfactory.AddParameter(lstParam, "@cl_address", this._clientsm.CLADDRESS);
            updates = updates.Replace("#cl_code", TableStructM.Info_Clients.CL_CODE);
            this._dbfactory.AddParameter(lstParam, "@cl_code", this._clientsm.CLCODE);
            updates = updates.Replace("#cl_bank", TableStructM.Info_Clients.CL_BANK);
            this._dbfactory.AddParameter(lstParam, "@cl_bank", this._clientsm.CLBANK);
            updates = updates.Replace("#cl_account", TableStructM.Info_Clients.CL_ACCOUNT);
            this._dbfactory.AddParameter(lstParam, "@cl_account", this._clientsm.CLACCOUNT);
            updates = updates.Replace("#cl_belong", TableStructM.Info_Clients.CL_BELONG);
            this._dbfactory.AddParameter(lstParam, "@cl_belong", this._clientsm.CLBELONG);
            where = where.Replace("#cl_id", TableStructM.Info_Clients.CL_ID);
            this._dbfactory.AddParameter(lstParam, "@id", this._clientsm.CLID);
            return this._dbfactory.Update(TableStructM.Info_Clients.TABLENAME, updates, where, lstParam);
        }
        #endregion
    }
}
