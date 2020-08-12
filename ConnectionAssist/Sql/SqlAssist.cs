using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionAssist.Sql
{
    /// <summary>
    /// Sql数据库辅助类
    /// </summary>
    public class SqlAssist : DbAssist
    {
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="strconnection">数据库链接字符串</param>
        public SqlAssist(string strconnection)
        {
            base._connection = new SqlConnection(strconnection);
            base.CreateConnection();
            base._command = new SqlCommand() { Connection = base._connection as SqlConnection };
        }
        #endregion
        #region 方法
        /// <summary>
        /// 获取数据阅读器
        /// </summary>
        /// <param name="sql">SQL查询语句</param>
        /// <param name="lstParam">参数列表</param>
        public override void GetDataReader(string sql, List<IDataParameter> lstParam = null)
        {
            base.GetDataReader(sql, lstParam);
        }
        /// <summary>
        /// 判断数据阅读器是否有效
        /// </summary>
        /// <returns>T=有效；F=无效</returns>
        public override bool IsEffect()
        {
            return (base._reader != null && (base._reader as SqlDataReader).HasRows);
        }
        /// <summary>
        /// 添加参数到参数链表中
        /// </summary>
        /// <param name="lstParam">参数链表</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="value">参数值</param>
        public override void AddParameter(List<IDataParameter> lstParam, string parameterName, object value)
        {
            lstParam.Add(new SqlParameter(parameterName, value));
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="tablenm">表名</param>
        /// <returns>数据适配器</returns>
        public override IDataAdapter GetDataSet(string sql, string tablenm)
        {
            if (base._ds == null) { base._ds = new DataSet(); }
            SqlDataAdapter adapter = new SqlDataAdapter(sql, this._connection as SqlConnection);
            adapter.Fill(base._ds, tablenm);
            return adapter;
        }
        #endregion
    }
   
}
