using PublicMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDAL
{
    /// <summary>
    /// 公用方法类（数据链路层）
    /// </summary>
    internal static class CommonMethods
    {
        /// <summary>
        /// 组装字段前缀
        /// </summary>
        /// <param name="alias">表别名</param>
        /// <returns>字段前缀</returns>
        internal static string CombineFieldPrefix(string alias = "")
        {
            return (string.IsNullOrEmpty(alias) ? "" : string.Format("{0}_", alias));
        }
        /// <summary>
        /// 拼接字段别名
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="alias">表别名</param>
        /// <returns>字段别名</returns>
        internal static string CombineFieldAlias(string field, string alias = "")
        {
            return string.Format("{0}{1}", (string.IsNullOrEmpty(alias) ? "" : string.Format("{0}_", alias)), field);
        }
        /// <summary>
        /// 拼装时间字段
        /// </summary>
        /// <param name="dt">时间</param>
        /// <param name="fields">字段</param>
        /// <param name="values">值</param>
        /// <param name="fieldname">字段名称</param>
        internal static void CombineDateTimeField(DateTime? dt, ref string fields, ref string values, string fieldname)
        {
            if (dt != null)
            {
                fields = string.Format("{0}, {1}", fields, fieldname);
                values = string.Format("{0}, '{1}'", values, dt.ToFormatString());
            }
            else
            {
                fields = string.Format("{0}, {1}", fields, fieldname);
                values = string.Format("{0}, '{1}'", values, Methods.DateNowToString());
            }
        }
    }
}
