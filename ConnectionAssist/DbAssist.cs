using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionAssist
{
    /// <summary>
    /// 数据库辅助类
    /// </summary>
    public abstract class DbAssist : IDbAssist
    {
        #region 变量
        /// <summary>
        /// 数据库操作类
        /// </summary>
        protected IDbConnection _connection;
        /// <summary>
        /// 数据库命令类
        /// </summary>
        protected IDbCommand _command;
        /// <summary>
        /// 数据集
        /// </summary>
        protected DataSet _ds;
        /// <summary>
        /// 数据阅读器
        /// </summary>
        protected IDataReader _reader;
        #endregion
        #region 属性
        /// <summary>
        /// 数据集
        /// </summary>
        public DataSet Data
        {
            get { return this._ds; }
        }
        /// <summary>
        /// 数据阅读器
        /// </summary>
        public IDataReader Reader
        {
            get { return this._reader; }
        }
        #endregion
        #region 方法
        /// <summary>
        /// 创建数据库链接
        /// </summary>
        public void CreateConnection()
        {
            try
            {
                this._connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}\n({1})", "访问数据库失败", ex.Message));
            }
        }
        /// <summary>
        /// 关闭数据库链接
        /// </summary>
        public void CloseConnection()
        {
            if (this.IsConnectOpen())
            {
                this._connection.Close();
                this._connection.Dispose();
                this._connection = null;
            }
        }
        /// <summary>
        /// 判断数据库链接是否打开
        /// </summary>
        /// <returns>T=打开;F=关闭</returns>
        public bool IsConnectOpen()
        {
            if (this._connection.State == ConnectionState.Open)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 获取数据阅读器
        /// </summary>
        /// <param name="sql">SQL查询语句</param>
        /// <param name="lstParam">参数列表</param>
        public virtual void GetDataReader(string sql, List<IDataParameter> lstParam = null)
        {
            this._command.CommandType = CommandType.Text;
            this._command.CommandText = sql;
            if (lstParam != null) lstParam.ForEach(p => this._command.Parameters.Add(p));
            this._reader = this._command.ExecuteReader();
        }
        /// <summary>
        /// 判断数据阅读器是否有效
        /// </summary>
        /// <returns>T=有效；F=无效</returns>
        public abstract bool IsEffect();
        /// <summary>
        /// 判断数据集是否有效
        /// </summary>
        /// <param name="tablenm">表名</param>
        /// <returns>T=有效；F=无效</returns>
        public bool IsEffect(string tablenm)
        {
            if (this._ds != null && this._ds.Tables[tablenm] != null && this._ds.Tables[tablenm].Rows.Count > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 判断数据行是否有效
        /// </summary>
        /// <param name="row">数据行</param>
        /// <returns>T=有效；F=无效</returns>
        public bool IsEffect(DataRow row)
        {
            if (row != null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 关闭数据阅读器
        /// </summary>
        public void CloseDataReader()
        {
            if (this._reader != null)
            {
                this._reader.Close();
                this._reader.Dispose();
                this._reader = null;
                this.ClearCommand();
            }
        }
        /// <summary>
        /// 添加参数到参数链表中
        /// </summary>
        /// <param name="lstParam">参数链表</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="value">参数值</param>
        public abstract void AddParameter(List<IDataParameter> lstParam, string parameterName, object value);
        /// <summary>
        /// 清除命令中的参数
        /// </summary>
        public void ClearCommand()
        {
            if (this._command.Parameters.Count > 0) this._command.Parameters.Clear();
        }
        /// <summary>
        /// 执行数据库语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="lstParam">参数列表</param>
        /// <returns>受影响的行数</returns>
        public int Execute(string sql, List<IDataParameter> lstParam = null)
        {
            this._command.CommandType = CommandType.Text;
            this._command.CommandText = sql;
            if (lstParam != null) lstParam.ForEach(p => this._command.Parameters.Add(p));
            int result = this._command.ExecuteNonQuery();
            this.ClearCommand();//清除命令中的参数
            return result;
        }
        /// <summary>
        /// 执行数据库语句并返回结果集的第一行第一列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="lstParam">参数列表</param>
        /// <returns>返回结果集的第一行第一列</returns>
        public object ExecuteScalar(string sql, List<IDataParameter> lstParam = null)
        {
            this._command.CommandType = CommandType.Text;
            this._command.CommandText = sql;
            if (lstParam != null) lstParam.ForEach(p => this._command.Parameters.Add(p));
            object result = this._command.ExecuteScalar();
            this.ClearCommand();//清除命令中的参数
            return result;
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="tablenm">表名</param>
        /// <returns>数据适配器</returns>
        public abstract IDataAdapter GetDataSet(string sql, string tablenm);
        /// <summary>
        /// 关闭数据集
        /// </summary>
        public void CloseDataSet()
        {
            if (this._ds != null)
            {
                this._ds.Clear();
                this._ds.Dispose();
                this._ds = null;
            }
        }
        /// <summary>
        /// 关闭数据集中的数据表
        /// </summary>
        /// <param name="tablenm">表名</param>
        public void CloseDataSet(string tablenm)
        {
            if (this._ds != null && this._ds.Tables[tablenm] != null)
            {
                this._ds.Tables[tablenm].Clear();
                this._ds.Tables[tablenm].Dispose();
            }
        }
        #endregion
    }
  
}
