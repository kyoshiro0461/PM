using PMCommon;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMBLL.Sections
{
    /// <summary>
    /// 用户配置节点
    /// </summary>
    internal class MenuSection : InstanceSection
    {
        /// <summary>
        /// 获取数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataMenuMethod", IsRequired = true)]
        internal string GetDataMenuMethod
        {
            get { return this["GetDataMenuMethod"].ToString(); }
            set { this["GetDataMenuMethod"] = value; }
        }
    }
}
