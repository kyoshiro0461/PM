using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMBLL.Common
{
    /// <summary>
    /// 公用方法类（业务逻辑层）
    /// </summary>
    internal static class CommonMethods
    {
        /// <summary>
        /// 获取配置文件路径
        /// </summary>
        /// <returns>配置文件路径</returns>
        internal static string GetConfigPath()
        {
            return string.Format("{0}\\Config\\BllApp.config", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
