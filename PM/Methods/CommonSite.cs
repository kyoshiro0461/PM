using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.Methods
{
    /// <summary>
    /// 公共路径类
    /// </summary>
    public static class CommonSite
    {
        /// <summary>
        /// 获取首页地址(后台)
        /// </summary>
        /// <returns>地址</returns>
        public static string GetIndexSite()
        {
            string site = string.Format("../../");
            return site;
        }

    }
}