using PM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.Methods
{
    /// <summary>
    /// 视图公用方法类
    /// </summary>
    public static class ViewMethods
    {
        /// <summary>
        /// 是否存在指定键值的Cookie
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="key">键值</param>
        /// <returns>T=存在；F=不存在</returns>
        public static bool IsExistCookie(HttpRequestBase request, string key)
        {
            if (request.Cookies[key] != null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 添加对应键值到Cookie中
        /// </summary>
        /// <param name="response">Http响应</param>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间</param>
        public static void AddCookie(HttpResponseBase response, string key, string value, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(key);
            cookie.Value = value;
            cookie.Expires = expires;
            response.Cookies.Add(cookie);
        }
        /// <summary>
        /// 添加对应键值到Cookie中
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="response">Http响应</param>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间</param>
        public static void SetCookie(HttpRequestBase request, HttpResponseBase response, string key, string value, DateTime expires)
        {
            if (!IsExistCookie(request, key))
                AddCookie(response, key, value, expires);
            else
                SetCookie(response, key, value);
        }
        /// <summary>
        /// 设置Cookie指定数据的值
        /// </summary>
        /// <param name="response">Http响应</param>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        public static void SetCookie(HttpResponseBase response, string key, string value)
        {
            response.Cookies[key].Value = value;
        }
        /// <summary>
        /// 获取Cookie指定数据的值
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="key">主键</param>
        /// <returns>值</returns>
        public static string GetCookie(HttpRequestBase request, string key)
        {
            try
            {
                return request.Cookies[key].Value;
            }
            catch (Exception)
            {
                return "";
            }
        }
        /// <summary>
        /// 获取Cookie值
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public static object GetCookie(string key)
        {
            object result = null;
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[key];
            if (cookie != null)
            {
                result = cookie.Value;
            }
            return result;
        }
        /// <summary>
        /// 从Cookie移除指定主键
        /// </summary>
        /// <param name="request">Http请求</param>
        /// <param name="key">主键</param>
        public static void RemoveCookie(HttpRequestBase request, string key)
        {
            request.Cookies.Remove(key);
        }
        /// <summary>
        /// 添加对应键值到Session中
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        public static void AddSession(string key, object value)
        {
            HttpContext.Current.Session.Add(key, value);
        }
        /// <summary>
        /// 设置Session的值
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        public static void SetSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
        /// <summary>
        /// 获取Session指定数据的值
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>值</returns>
        public static object GetSession(string key)
        {
            return HttpContext.Current.Session[key];
        }
        /// <summary>
        /// 提示并跳转
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="url">网址（1=返回上一页；2=返回上两页；其他=网址）</param>
        /// <returns></returns>
        public static string AlertGo(string msg, string url = "")
        {
            string result = "";
            switch (url)
            {
                case "-1":
                case "-2":
                    result = string.Format("<script>alert('{0}');history.go({1});</script>", msg, url); break;
                default:
                    if (string.IsNullOrEmpty(url))
                        result = string.Format("<script>alert('{0}');</script>", msg);
                    else
                        result = string.Format("<script>alert('{0}');location.href='{1}'</script>", msg, url);
                    break;
            }
            return result;
        }
        /// <summary>
        /// 提示并返回文本结果
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="url">网址（1=返回上一页；2=返回上两页；其他=网址）</param>
        /// <returns>结果</returns>
        public static ActionResult AlertBack(string msg, string url = "")
        {
            return new ContentResult() { Content = AlertGo(msg, url), ContentType = "text/html" };
        }
        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns>行为结果</returns>
        public static ActionResult SkipTo(string url = "")
        {
            if (string.IsNullOrEmpty(url)) { url = "/"; }
            return new ContentResult() { Content = string.Format("<script>location.href='{0}'</script>", url), ContentType = "text/html" };
        }
        /// <summary>
        /// 获取提交数据
        /// </summary>
        /// <param name="request">请求类</param>
        /// <param name="element">元素</param>
        /// <param name="type">传值类型</param>
        /// <returns>获取的数据</returns>
        public static string GetForm(HttpRequestBase request, string element, CommonEnums.ValueEnum type = CommonEnums.ValueEnum.vlGet)
        {
            string result = "";
            switch (type)
            {
                case CommonEnums.ValueEnum.vlPost:
                    result = request.Form[element];
                    break;
                case CommonEnums.ValueEnum.vlGet:
                    result = request.QueryString[element];
                    break;

            }
            return result;
        }

        /// <summary>
        /// 获取链接工厂类
        /// </summary>
        /// <returns>链接工厂类</returns>
        public static ConnectionFactory GetConnection()
        {
            ConnectionFactory result = GetSession(CommonParams.SESSION_CONNECTION) as ConnectionFactory;
            if (result == null)
            {
                result = new ConnectionFactory();
                AddSession(CommonParams.SESSION_CONNECTION, result);
            }
            return result;
        }
    }
}