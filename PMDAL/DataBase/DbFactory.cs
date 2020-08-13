using ConnectionAssist;
using PublicMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PMDAL.DataBase
{
    /// <summary>
    /// 数据库工厂类
    /// </summary>
    public class DbFactoryD
    {
        #region 枚举
        /// <summary>
        /// 数据库类型
        /// </summary>
        public enum DataBaseType
        {
            /// <summary>
            /// Sql数据库
            /// </summary>
            dtSQL = 0,
            /// <summary>
            /// Access数据库
            /// </summary>
            dtAccess = 1,
        }
        #endregion
        #region 变量
        private string _strconnection;                  //数据库链接字符串
        private IDbAssist _dbAssist;                    //数据库辅助类
        #endregion
        #region 属性
        /// <summary>
        /// 数据集
        /// </summary>
        public DataSet Data
        {
            get { return this._dbAssist.Data; }
        }
        /// <summary>
        /// 数据阅读器
        /// </summary>
        public IDataReader Reader
        {
            get { return this._dbAssist.Reader; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public DbFactoryD()
        {
            InitFactory();//初始化工厂
        }
        #endregion
        #region 方法
        /// <summary>
        /// 初始化工厂
        /// </summary>
        private void InitFactory()
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
        private void ReadConfigFile(ref string strNameSpace, ref string strInstance)
        {
            DataBaseType type = DataBaseType.dtSQL;
            string configPath = string.Format("{0}\\Config\\DalApp.config", AppDomain.CurrentDomain.BaseDirectory);
            const string GROUPNAME = "DataBaseGroup";
            const string SECTIONNAME = "SetDataBase";
            //读取配置文件的信息
            Sections.DataBaseSection section = Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.DataBaseSection;
            if (section != null)
            {
                type = ConvertDataBaseType(section.Type);//数据库类型
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
            }
            //根据数据库类型获取数据库链接字符串
            switch (type)
            {
                case DataBaseType.dtAccess:
                    break;
                case DataBaseType.dtSQL:
                    this._strconnection = Methods.ReadConfigFile_ConnectionStrings(configPath);//读取链接字符串信息
                    break;
            }
        }
        /// <summary>
        /// 转换数据库类型
        /// </summary>
        /// <param name="strType">数据库类型字符串</param>
        /// <returns>数据库类型枚举</returns>
        private DataBaseType ConvertDataBaseType(string strType)
        {
            switch (strType.ToUpper())
            {
                case "ACCESS":
                    return DataBaseType.dtAccess;
                default:
                    return DataBaseType.dtSQL;
            }
        }
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="strInstance">实例名</param>
        private void InstanceObject(string strNameSpace, string strInstance)
        {
            this._dbAssist = Methods.InstanceObject(strNameSpace, strInstance, this._strconnection) as IDbAssist;
        }
        /// <summary>
        /// 获取数据阅读器
        /// </summary>
        /// <param name="sql">SQL查询语句</param>
        /// <param name="lstParam">参数列表</param>
        public void GetDataReader(string sql, List<IDataParameter> lstParam = null)
        {
            this._dbAssist.GetDataReader(sql, lstParam);
        }
        /// <summary>
        /// 判断数据阅读器是否有效
        /// </summary>
        /// <returns>T=有效；F=无效</returns>
        public bool IsEffect()
        {
            return this._dbAssist.IsEffect();
        }
        /// <summary>
        /// 判断数据集是否有效
        /// </summary>
        /// <param name="tablenm">表名</param>
        /// <returns>T=有效；F=无效</returns>
        public bool IsEffect(string tablenm)
        {
            return this._dbAssist.IsEffect(tablenm);
        }
        /// <summary>
        /// 判断数据行是否有效
        /// </summary>
        /// <param name="row">数据行</param>
        /// <returns>T=有效；F=无效</returns>
        public bool IsEffect(DataRow row)
        {
            return this._dbAssist.IsEffect(row);
        }
        /// <summary>
        /// 关闭数据阅读器
        /// </summary>
        public void CloseDataReader()
        {
            this._dbAssist.CloseDataReader();
        }
        /// <summary>
        /// 添加参数到参数链表中
        /// </summary>
        /// <param name="lstParam">参数链表</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="value">参数值</param>
        public void AddParameter(List<IDataParameter> lstParam, string parameterName, object value)
        {
            this._dbAssist.AddParameter(lstParam, parameterName, value);
        }
        /// <summary>
        /// 清除命令中的参数
        /// </summary>
        public void ClearCommand()
        {
            this._dbAssist.ClearCommand();
        }
        /// <summary>
        /// 执行数据库语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="lstParam">参数列表</param>
        /// <param name="user">用户信息类（模型层）</param>
        /// <param name="ip">IP地址</param>
        /// <param name="islogging">是否记录日志</param>
        /// <returns>受影响的行数</returns>
        public int Execute(string sql, List<IDataParameter> lstParam = null)
        {
            int result = this._dbAssist.Execute(sql, lstParam);
           
            return result;
        }
        /// <summary>
        /// 执行数据库语句并返回结果集的第一行第一列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="lstParam">参数列表</param>
        /// <param name="user">用户信息类（模型层）</param>
        /// <param name="ip">IP地址</param>
        /// <param name="islogging">是否记录日志</param>
        /// <returns>返回结果集的第一行第一列</returns>
        public object ExecuteScalar(string sql, List<IDataParameter> lstParam = null)
        {
            object result = this._dbAssist.ExecuteScalar(sql, lstParam);//用于返回续编的序号
           
            return result;
        }
        /// <summary>
        /// 记录数据库操作
        /// </summary>
        /// <param name="sql">操作语句</param>
        /// <param name="lstParam">参数列表</param>
        /// <param name="ip">IP地址</param>
        /// <param name="user">用户信息类（模型层）</param>
       /* public void RecordDBOperate(string sql, List<IDataParameter> lstParam = null, AUserM user = null, string ip = "")
        {
            //insert into log_database(db_lid, db_userid, db_username, db_ip, db_addtime, db_content) values('', '', '', '', '', '', '')
            string fields = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                TableStructM.Log_Database.DB_LID, TableStructM.Log_Database.DB_USERID, TableStructM.Log_Database.DB_USERNAME, TableStructM.Log_Database.DB_IP, TableStructM.Log_Database.DB_ADDTIME,
                TableStructM.Log_Database.DB_CONTENT);
            string uid = "0";
            string username = "";
            if (user != null) { uid = user.ID; username = user.Name; }
            sql = GetCompleteSyntax(sql, lstParam);
            string values = string.Format("{0}, {1}, '{2}', '{3}', getdate(), '{4}'", 1, uid, username.ReplaceStr(), ip.ReplaceStr(), sql.ReplaceStr());
            string log_sql = string.Format("insert into {0}({1}) values({2})", TableStructM.Log_Database.TABLENAME, fields, values);
            int result = this._dbAssist.Execute(log_sql);
        }
        */
        /// <summary>
        /// 获取完整语法
        /// </summary>
        /// <param name="sql">Sql语法</param>
        /// <param name="lstParam">参数列表</param>
        /// <returns></returns>
        public string GetCompleteSyntax(string sql, List<IDataParameter> lstParam = null)
        {
            if (lstParam != null) lstParam.ToList().ForEach(p => sql = sql.Replace(p.ParameterName, p.Value.ToString()));
            return sql;
        }
        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="condition">其他条件（不包含where）</param>
        /// <param name="lstParam">条件参数链表</param>
        /// <returns>T=存在；F=不存在</returns>
        public bool IsExist(string table, string condition = "", List<IDataParameter> lstParam = null)
        {
            long count = GetCount(table, condition, lstParam);
            return count > 0;
        }
        /// <summary>
        /// 获取笔数
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="condition">条件（不包含where）</param>
        /// <param name="lstParam">条件参数链表</param>
        /// <param name="fields">统计字段</param>
        /// <returns>笔数</returns>
        public long GetCount(string table, string condition = "", List<IDataParameter> lstParam = null, string fields = "*")
        {
            const string FIELDNM_COUNTS = "counts";//字段名
            long result = 0;
            string sql = string.Format("select count({0}) as {1} from {2} {3}", fields, FIELDNM_COUNTS, table, condition);
            this.GetDataReader(sql, lstParam);

            if (this.IsEffect())
            {
                this.Reader.Read();
                result = this.Reader[FIELDNM_COUNTS].ConvertToInt64();
            }

            this.CloseDataReader();

            return result;
        }
        /// <summary>
        /// 获取总和
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="field">统计的字段</param>
        /// <param name="condition">条件（不包含where）</param>
        /// <param name="lstParam">条件参数链表</param>
        /// <returns></returns>
        public decimal GetSum(string table, string field, string condition = "", List<IDataParameter> lstParam = null)
        {
            const string FIELDNM_TOTAL = "total";//字段名
            decimal result = 0;
            string sql = string.Format("select sum({0}) as {1} from {2} {3}", field, FIELDNM_TOTAL, table, condition);
            this.GetDataReader(sql, lstParam);

            if (this.IsEffect())
            {
                this.Reader.Read();
                result = this.Reader[FIELDNM_TOTAL].ConvertToDecimal();
            }

            this.CloseDataReader();
            return result;
        }
        /// <summary>
        /// 获取指定列的最大值
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="field">字段名</param>
        /// <param name="condition">条件语句（不包含where）</param>
        /// <param name="lstParam">参数链表</param>
        /// <returns>最大值</returns>
        public long GetMax(string table, string field, string condition = "", List<IDataParameter> lstParam = null)
        {
            const string FIELDNM_MAXS = "maxs";//字段名
            long result = 0;

            string sql = string.Format("select max(cast({0} as bigint)) as {1} from {2} {3}", field, FIELDNM_MAXS, table, condition);
            this.GetDataReader(sql, lstParam);

            if (this.IsEffect())
            {
                this.Reader.Read();
                result = this.Reader[FIELDNM_MAXS].ConvertToInt64();
            }

            this.CloseDataReader();

            return result;
        }
        /// <summary>
        /// 获取指定字段的值
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="field">字段名</param>
        /// <param name="condition">条件语句（需带入where）</param>
        /// <param name="orderby">排序语句（需带入order by）</param>
        /// <param name="lstParam">参数链表</param>
        /// <returns>值</returns>
        public object GetValue(string table, string field, string condition = "", string orderby = "", List<IDataParameter> lstParam = null)
        {
            object result = null;
            string sql = string.Format("select {0} from {1} {2} {3}", field, table, condition, orderby);
            this.GetDataReader(sql, lstParam);

            if (this.IsEffect())
            {
                this.Reader.Read();
                result = this.Reader[field];
            }
            this.CloseDataReader();

            return result;
        }
        /// <summary>
        /// 插入语句
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="fields">字段</param>
        /// <param name="values">值</param>
        /// <param name="lstParam">参数链表</param>
        /// <param name="user">用户信息类（模型层）</param>
        /// <param name="ip">IP地址</param>
        /// <param name="islogging">是否记录日志</param>
        /// <returns>受影响的行数</returns>
        public int Insert(string table, string fields, string values, List<IDataParameter> lstParam = null)
        {
            string sql = string.Format("insert into {0}({1}) values({2})", table, fields, values);
            return this.Execute(sql, lstParam);
        }
        /// <summary>
        /// 插入语句并获取自动编号
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="fields">字段</param>
        /// <param name="values">值</param>
        /// <param name="lstParam">参数链表</param>
        /// <param name="user">用户信息类（模型层）</param>
        /// <param name="ip">IP地址</param>
        /// <param name="islogging">是否记录日志</param>
        /// <returns>受影响的行数</returns>
        public object InsertGetAutoID(string table, string fields, string values, List<IDataParameter> lstParam = null)
        {
            string sql = string.Format("insert into {0}({1}) values({2});select @@IDENTITY", table, fields, values);
            return this.ExecuteScalar(sql, lstParam);
        }
        /// <summary>
        /// 更新语句
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="updates">更新语法</param>
        /// <param name="condition">条件语句（需带入where）</param>
        /// <param name="lstParam">参数链表</param>
        /// <param name="user">用户信息类（模型层）</param>
        /// <param name="ip">IP地址</param>
        /// <param name="islogging">是否记录日志</param>
        /// <returns>受影响的行数</returns>
        public int Update(string table, string updates, string condition = "", List<IDataParameter> lstParam = null)
        {
            string sql = string.Format("update {0} set {1} {2}", table, updates, condition);
            return this.Execute(sql, lstParam);
        }
        /// <summary>
        /// 删除语句
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="condition">条件语句（需带入where）</param>
        /// <param name="lstParam">参数链表</param>
        /// <param name="userm">用户信息类（模型层）</param>
        /// <param name="ip">IP地址</param>
        /// <param name="islogging">是否记录日志</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string table, string condition = "", List<IDataParameter> lstParam = null)
        {
            string sql = string.Format("delete from {0} {1}", table, condition);
            return this.Execute(sql, lstParam);
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="tablenm">表名</param>
        /// <returns>数据适配器</returns>
        public IDataAdapter GetDataSet(string sql, string tablenm)
        {
            return this._dbAssist.GetDataSet(sql, tablenm);
        }
        /// <summary>
        /// 关闭数据集
        /// </summary>
        public void CloseDataSet()
        {
            this._dbAssist.CloseDataSet();
        }
        /// <summary>
        /// 关闭数据集中的数据表
        /// </summary>
        /// <param name="tablenm">表名</param>
        public void CloseDataSet(string tablenm)
        {
            this._dbAssist.CloseDataSet(tablenm);
        }
        #endregion
    }
}
