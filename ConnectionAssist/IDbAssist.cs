using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionAssist
{
    /// <summary>
    /// 数据库辅助借口
    /// </summary>
    public interface IDbAssist
    {
        /// <summary>
        /// 数据集
        /// </summary>
        DataSet Data { get; }
        /// <summary>
        /// 数据阅读器
        /// </summary>
        IDataReader Reader { get; }
        /// <summary>
        /// 创建数据库链接
        /// </summary>
        void CreateConnection();
        /// <summary>
        /// 关闭数据库链接
        /// </summary>
        void CloseConnection();
        /// <summary>
        /// 判断数据库链接是否打开
        /// </summary>
        /// <returns>T=打开;F=关闭</returns>
        bool IsConnectOpen();
        /// <summary>
        /// 获取数据阅读器
        /// </summary>
        /// <param name="sql">SQL查询语句</param>
        /// <param name="lstParam">参数列表</param>
        void GetDataReader(string sql, List<IDataParameter> lstParam = null);
        /// <summary>
        /// 判断数据阅读器是否有效
        /// </summary>
        /// <returns>T=有效；F=无效</returns>
        bool IsEffect();
        /// <summary>
        /// 判断数据集是否有效
        /// </summary>
        /// <param name="tablenm">表名</param>
        /// <returns>T=有效；F=无效</returns>
        bool IsEffect(string tablenm);
        /// <summary>
        /// 判断数据行是否有效
        /// </summary>
        /// <param name="row">数据行</param>
        /// <returns>T=有效；F=无效</returns>
        bool IsEffect(DataRow row);
        /// <summary>
        /// 关闭数据阅读器
        /// </summary>
        void CloseDataReader();
        /// <summary>
        /// 添加参数到参数链表中
        /// </summary>
        /// <param name="lstParam">参数链表</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="value">参数值</param>
        void AddParameter(List<IDataParameter> lstParam, string parameterName, object value);
        /// <summary>
        /// 清除命令中的参数
        /// </summary>
        void ClearCommand();
        /// <summary>
        /// 执行数据库语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="lstParam">参数列表</param>
        /// <returns>受影响的行数</returns>
        int Execute(string sql, List<IDataParameter> lstParam = null);
        /// <summary>
        /// 执行数据库语句并返回结果集的第一行第一列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="lstParam">参数列表</param>
        /// <returns>返回结果集的第一行第一列</returns>
        object ExecuteScalar(string sql, List<IDataParameter> lstParam = null);
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="tablenm">表名</param>
        /// <return>数据适配器</return>
        IDataAdapter GetDataSet(string sql, string tablenm);
        /// <summary>
        /// 关闭数据集
        /// </summary>
        void CloseDataSet();
        /// <summary>
        /// 关闭数据集中的数据表
        /// </summary>
        /// <param name="tablenm">表名</param>
        void CloseDataSet(string tablenm);
    }
}
