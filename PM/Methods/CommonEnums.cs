using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.Methods
{
    /// <summary>
    /// 公共枚举类
    /// </summary>
    public static class CommonEnums
    {
        /// <summary>
        /// 传值方式
        /// </summary>
        public enum ValueEnum
        {
            /// <summary>
            /// Get传值
            /// </summary>
            vlGet = 0,
            /// <summary>
            /// Post传值
            /// </summary>
            vlPost = 1,
        }
    }
}