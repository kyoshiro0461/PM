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
    /// 项目配置节点
    /// </summary>
    internal class ProjectsSection : InstanceSection
    {
        /// <summary>
        /// 获取数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataProjectsMethod", IsRequired = true)]
        internal string GetDataProjectsMethod
        {
            get { return this["GetDataProjectsMethod"].ToString(); }
            set { this["GetDataProjectsMethod"] = value; }
        }
        /// <summary>
        /// 获取分页数据方法名
        /// </summary>
        [ConfigurationProperty("GetPageDataMethod", IsRequired = true)]
        internal string GetPageDataMethod
        {
            get { return this["GetPageDataMethod"].ToString(); }
            set { this["GetPageDataMethod"] = value; }
        }
        /// <summary>
        /// 判断项目是否存在方法名
        /// </summary>
        [ConfigurationProperty("IsExist_projectsnameMethod", IsRequired = true)]
        internal string IsExist_projectsnameMethod
        {
            get { return this["IsExist_projectsnameMethod"].ToString(); }
            set { this["IsExist_projectsnameMethod"] = value; }
        }

        /// <summary>
        /// 根据编号获取项目数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataByIDMethod", IsRequired = true)]
        internal string GetDataByIDMethod
        {
            get { return this["GetDataByIDMethod"].ToString(); }
            set { this["GetDataByIDMethod"] = value; }
        }
    }
}
