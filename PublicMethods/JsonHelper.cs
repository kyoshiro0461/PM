using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PublicMethods
{
    /// <summary>
    /// JSon辅助类
    /// </summary>
    /// <typeparam name="T">JSon转化类型</typeparam>
    public static class JSonHelper<T>
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>字符串</returns>
        public static string ObjectToJson(object o)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(o);
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>对象</returns>
        public static T JsonToObject(string str)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<T>(str);
        }
    }
}
