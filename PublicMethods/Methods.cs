using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PublicMethods
{
    /// <summary>
    /// 公用方法类
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="filePath">配置文件路径</param>
        /// <returns>配置文件</returns>
        public static Configuration ReadConfigFile(string filePath)
        {
            Configuration result = null;
            if (string.IsNullOrEmpty(filePath)) { return result; }

            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = filePath;
            result = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            return result;
        }
        /// <summary>
        /// 读取配置文件（SectionGroup节点）
        /// </summary>
        /// <param name="filePath">配置文件路径</param>
        /// <param name="groupName">配置节点组名称</param>
        /// <param name="sectionName">配置节点名称</param>
        /// <returns>对象</returns>
        public static object ReadConfigFile_SectionGroup(string filePath, string groupName, string sectionName)
        {
            object result = null;

            Configuration config = ReadConfigFile(filePath);//读取配置文件路径
            if (config != null)
            {
                ConfigurationSectionGroup group = config.SectionGroups[groupName];//获取配置节点组
                if (group != null) result = group.Sections[sectionName] as object;//获取节点
            }

            return result;
        }
        /// <summary>
        /// 读取配置文件（ConnectionStrings节点）
        /// </summary>
        /// <param name="filePath">配置文件路径</param>
        /// <returns>链接信息</returns>
        public static string ReadConfigFile_ConnectionStrings(string filePath)
        {
            string result = "";

            Configuration config = ReadConfigFile(filePath);//读取配置文件路径
            if (config != null) result = config.ConnectionStrings.ConnectionStrings["SqlConnection"].ConnectionString;

            return result;
        }
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="strInstance">实例名</param>
        /// <param name="args">参数列表</param>
        /// <returns>创建好的实例</returns>
        public static object InstanceObject(string strNameSpace, string strInstance, params object[] args)
        {
            object result = null;
            try
            {
                Assembly assembly = Assembly.Load(strNameSpace);//获取程序集
                Type t = assembly.GetType(strInstance);//获取实例类型  
                result = Activator.CreateInstance(t, args);
            }
            catch (Exception ex)
            {
                throw new Exception("创建实例出错,请与服务商联系：" + ex.InnerException.Message);
            }
            return result;
        }
        /// <summary>
        /// 反射调用方法（实例化对象）
        /// </summary>
        /// <param name="target">调用对象</param>
        /// <param name="methodname">方法名</param>
        /// <param name="parametertypes">参数类型数组</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>结果</returns>
        public static object ReflexInvokeMethod(object target, string methodname, Type[] parametertypes, object[] parameters)
        {
            Object obj = null;
            Type t = target.GetType();
            MethodInfo info = t.GetMethod(methodname, parametertypes);//获取方法
            if (info != null) obj = info.Invoke(target, parameters);
            return obj;
        }
        /// <summary>
        /// 反射调用方法（未实例化对象）
        /// </summary>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="strInstance">实例名</param>
        /// <param name="methodname">方法名</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>结果</returns>
        public static object ReflexInvokeMethod(string strNameSpace, string strInstance, string methodname, object[] parameters)
        {
            Object obj = null;
            Assembly assembly = Assembly.Load(strNameSpace);//获取程序集
            Type t = assembly.GetType(strInstance);//获取实例类型  
            MethodInfo info = t.GetMethod(methodname);//获取方法
            if (info != null) obj = info.Invoke(null, parameters);
            return obj;
        }
        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="point">小数位数</param>
        /// <returns>值</returns>
        public static decimal Round(decimal value, int point = 2)
        {
            return Math.Round(value, point);
        }
        
        
        /// <summary>
        /// 验证域名前缀只能为英文
        /// </summary>
        /// <returns>T=验证通过；F=验证失败</returns>
        public static bool CheckPrefix(string prfeix)
        {
            string emailStr = @"^[A-Za-z]+$";
            //邮箱正则表达式对象
            Regex emailReg = new Regex(emailStr);
            return emailReg.IsMatch(prfeix);
        }
        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns>T=为空；F=不为空</returns>
        public static bool IsNull(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Html字符编码
        /// </summary>
        /// <param name="value">Html字符串</param>
        /// <returns>编码后的Html</returns>
        public static string HtmlEncode(string value)
        {
            string result = "";
            if (string.IsNullOrEmpty(value)) return result;

            value = value.Replace("%", "&#037;");
            value = value.Replace("<", "&lt;");
            value = value.Replace(">", "&gt;");
            value = value.Replace((((char)34).ToString()), "&quot;");//Chr(34)是英文双引号
            value = value.Replace((((char)39).ToString()), "&#39;");//Chr(39)是英文单引号
            result = value;
            return result;
        }
        /// <summary>
        /// Html字符解码
        /// </summary>
        /// <param name="value">Html字符串</param>
        /// <returns>解码后的Html</returns>
        public static string HtmlDecode(string value)
        {
            string result = "";
            if (string.IsNullOrEmpty(value)) return result;

            value = value.Replace("&#037;", "%");
            value = value.Replace("&lt;", "<");
            value = value.Replace("&gt;", ">");
            value = value.Replace("&quot;", (((char)34).ToString()));
            value = value.Replace("&#39;", (((char)39).ToString()));
            result = value;
            return result;
        }
        /// <summary>
        /// 检查文件夹路径，不存在则创建
        /// </summary>
        /// <param name="path">文件夹路径</param>
        public static void CheckFolderPath(string path)
        {
            if (!System.IO.File.Exists(path)) System.IO.Directory.CreateDirectory(path);
        }
        /// <summary>
        /// 当前时间字符串
        /// </summary>
        /// <returns>字符串</returns>
        public static string DateNowToString()
        {
            return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
