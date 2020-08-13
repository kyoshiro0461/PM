using PMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PMDAL.Sections
{
    /// <summary>
    /// 数据库配置节点
    /// </summary>
    internal class DataBaseSection : InstanceSection
    {
        /// <summary>
        /// 数据库类型（SQL=Sql数据库；）
        /// </summary>
        [ConfigurationProperty("strType", IsRequired = true)]
        internal string Type
        {
            get { return this["strType"].ToString(); }
            set { this["strType"] = value; }
        }
    }
}
