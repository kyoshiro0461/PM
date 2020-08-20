using LDWeb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LDWeb.Custom.Script.asp
{
    /// <summary>
    /// imageUp 的摘要说明
    /// </summary>
    public class imageUp : IHttpHandler
    {
        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="context">HTTP请求</param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            //上传配置
            string pathbase = "upload/";//保存路径
            int size = 10;//文件大小限制,单位mb
            string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };//文件允许格式

            string callback = context.Request["callback"];
            string editorId = context.Request["editorid"];

            //上传图片
            Hashtable info;
            Uploader up = new Uploader();
            info = up.upFile(context, pathbase, filetype, size); //获取上传状态
            string json = BuildJson(info);

            context.Response.ContentType = "text/html";
            if (callback != null)
            {
                context.Response.Write(String.Format("<script>{0}(JSON.parse(\"{1}\"));</script>", callback, json));
            }
            else
            {
                context.Response.Write(json);
            }
        }
        /// <summary>
        /// 建立JSON
        /// </summary>
        /// <param name="info">集合</param>
        /// <returns>JSon字符串</returns>
        private string BuildJson(Hashtable info)
        {
            List<string> fields = new List<string>();
            string[] keys = new string[] { "originalName", "name", "url", "size", "state", "type" };
            for (int i = 0; i < keys.Length; i++)
            {
                fields.Add(String.Format("\"{0}\": \"{1}\"", keys[i], info[keys[i]]));
            }
            return "{" + String.Join(",", fields) + "}";
        }
        /// <summary>
        /// 是否可重复使用
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    /// <summary>
    /// 脚本类
    /// </summary>
    public class Script
    {
        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="message">信息</param>
        public static void Alert(string message)
        {
            ResponseScript("alert('" + message + "');");
        }
        /// <summary>
        /// 输出脚本
        /// </summary>
        /// <param name="script">脚本</param>
        public static void ResponseScript(string script)
        {
            HttpContext.Current.Response.Write("<script type=\"text/javascript\">\n//<![CDATA[\n");
            HttpContext.Current.Response.Write(script);
            HttpContext.Current.Response.Write("\n//]]>\n</script>\n");
        }
    }
}