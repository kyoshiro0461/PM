using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.Methods
{
    /// <summary>
    /// 公用方法类
    /// </summary>
    public static class CommonMethods
    {
        /// <summary>
        /// 获取配置文件路径
        /// </summary>
        /// <returns>配置文件路径</returns>
        public static string GetConfigPath()
        {
            return string.Format("{0}Config\\WebApp.config", AppDomain.CurrentDomain.BaseDirectory);
        }
        
        /// <summary>
        /// 获取域名前缀
        /// </summary>
        /// <returns>域名前缀</returns>
        public static string GetDomainPrefix()
        {
            string result = "";
            string domain = GetDomain();//获取域名
            if (!string.IsNullOrEmpty(domain))
            {
                if (domain.ToUpper().IndexOf(Methods.CommonParams.Site.ToUpper()) > 0)
                {
                    if (domain.IndexOf('.') > 0)
                    {
                        result = domain.Substring(0, domain.IndexOf('.'));
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 获取域名
        /// </summary>
        /// <returns>域名</returns>
        public static string GetDomain()
        {
            return HttpContext.Current.Request.Url.Host;
        }
        /// <summary>
        /// 判断是否为外链
        /// </summary>
        /// <returns>T=外链；F=内链</returns>
        public static bool IsOutLink()
        {
            string server1 = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
            string server2 = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            return !(server1 != null && server1.Contains(server2));
        }

        /// <summary>
        /// 获取上传文件夹路径
        /// </summary>
        /// <param name="rootpath"></param>
        /// <param name="foldername">文件夹名称</param>
        /// <returns>路径</returns>
        public static string GetUploadFolder(string rootpath, string foldername)
        {
            return string.Format("{0}{1}/{2}/", rootpath, "upload", foldername);
        }
        /// <summary>
        /// 清除面包屑
        /// </summary>
        /// <returns></returns>
        public static void ClearCrumb()
        {
            //Methods.CommonParams.CrumbCollect.Clear();
        }
        /// <summary>
        /// 向面包屑插入数据
        /// </summary>
        /// <param name="sortid">分类编号</param>
        /// <param name="title">标题</param>
        /// <param name="href">地址</param>
        //public static void InsertCrumb(string sortid, string title, string href)
        //{
        //    if (Methods.CommonParams.CrumbCollect == null) Methods.CommonParams.CrumbCollect = new List<Crumb>();
        //    if (Methods.CommonParams.CrumbCollect.Count == 0) Methods.CommonParams.CrumbCollect.Add(new Crumb(1, 0, "首页", "/") { });//若面包屑没有数据，则插入默认页
        //    int max = (Methods.CommonParams.CrumbCollect != null && Methods.CommonParams.CrumbCollect.Count > 0 ? Methods.CommonParams.CrumbCollect.Max(p => p.ID) : 0);
        //    int id = max + 1;
        //    Crumb crumb = Methods.CommonParams.CrumbCollect.Where(p => p.ID == max).FirstOrDefault();
        //    if (crumb != null) crumb.IsRightArrow = true;
        //    long sid = (string.IsNullOrEmpty(sortid) ? 0 : sortid.ConvertToInt64());
        //    Methods.CommonParams.CrumbCollect.Add(new Crumb(id, sid, title, href, false) { });
        //}

    }
}