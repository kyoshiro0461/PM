using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicMethods
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ExtendMethods
    {
        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="value">属性值</param>
        /// <returns>T=为空;F=不为空</returns>
        public static bool IsEmpty(this object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()) || value.GetType() == typeof(DBNull))
                return true;
            else
                return false;
        }
        /// <summary>
        /// 解决数据库单撇号问题
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string ReplaceStr(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            else
                return value.Replace("'", "''");
        }
        /// <summary>
        /// 将object转换为int32数据时，将空字符串转换为0
        /// </summary>
        /// <param name="value">数据</param>
        /// <returns>转换后的数值</returns>
        public static Int32 ConvertToInt32(this object value)
        {
            return value.ConvertToInt32(0);
        }
        /// <summary>
        /// 将object转换为int32数据时，将空字符串转换为默认值
        /// </summary>
        /// <param name="value">数据</param>
        /// <returns>转换后的数值</returns>
        public static Int32 ConvertToInt32(this object value, Int32 defaultvalue)
        {
            if (value.IsEmpty())
                return defaultvalue;
            else
                return Convert.ToInt32(value);
        }
        /// <summary>
        /// 将object转换为int64数据时，将空字符串转换为0
        /// </summary>
        /// <param name="value">数据</param>
        /// <returns>转换后的数值</returns>
        public static Int64 ConvertToInt64(this object value)
        {
            if (value.IsEmpty())
                return 0;
            else
                return Convert.ToInt64(value);
        }
        /// <summary>
        /// 将object转换为decimal数据时，将空字符串转换为0
        /// </summary>
        /// <param name="value">数据</param>
        /// <returns>转换后的数值</returns>
        public static decimal ConvertToDecimal(this object value)
        {
            if (value.IsEmpty())
                return 0;
            else
                return Convert.ToDecimal(value);
        }
        /// <summary>
        /// 将object转换为DateTime数据时，将空字符串转换为Null
        /// </summary>
        /// <param name="value">数据</param>
        /// <returns>转换后的数值</returns>
        public static DateTime? ConvertToDateTime(this object value)
        {
            if (value.IsEmpty())
                return null;
            else
                return Convert.ToDateTime(value);
        }
        /// <summary>
        /// 将object转换为bool数据时，将空字符串或0转换为false
        /// </summary>
        /// <param name="value">数据</param>
        /// <returns>转换后的数值</returns>
        public static bool ConvertToBool(this object value)
        {
            if (value.IsEmpty() || value.ToString() == "0")
                return false;
            else
                return true;
        }
        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns>T=为空；F=不为空</returns>
        public static bool IsNull(this object value)
        {
            return PublicMethods.Methods.IsNull(value);
        }
        /// <summary>
        /// 计算与当前时间的差--总秒数差
        /// </summary>
        /// <param name="value">时间值</param>
        /// <returns>差值</returns>
        public static double DiffPrecentTime(this DateTime? value)
        {
            TimeSpan? ts = value - DateTime.Now;
            return (ts != null && !ts.IsEmpty() ? ts.Value.TotalSeconds : 0.00);
        }
        /// <summary>
        /// 计算与当前时间的差--天数差
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int DiffPrecentDays(this DateTime? value)
        {
            TimeSpan? ts = value - DateTime.Now;
            return (ts != null && !ts.IsEmpty() ? ts.Value.Days : 0);
        }
        /// <summary>
        /// 时间格式化
        /// </summary>
        /// <returns>字符串</returns>
        public static string ToFormatString(this DateTime? value)
        {
            return string.Format("{0:yyyy/MM/dd HH:mm:ss}", value);
        }
    }
}
