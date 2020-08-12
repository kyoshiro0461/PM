using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCommon
{
    /// <summary>
    /// 实例配置节点抽象类
    /// </summary>
    public abstract class InstanceSection : ConfigurationSection
    {
        /// <summary>
        /// 数据库命名空间
        /// </summary>
        [ConfigurationProperty("strNameSpace", IsRequired = true)]
        public string NameSpace
        {
            get { return this["strNameSpace"].ToString(); }
            set { this["strNameSpace"] = value; }
        }
        /// <summary>
        /// 数据库实例名
        /// </summary>
        [ConfigurationProperty("strInstance", IsRequired = true)]
        public string Instance
        {
            get { return this["strInstance"].ToString(); }
            set { this["strInstance"] = value; }
        }
    }
    
}
