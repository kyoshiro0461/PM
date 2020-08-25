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
    /// 业主配置节点
    /// </summary>
    internal class ServiceTeamSection : InstanceSection
    {
        /// <summary>
        /// 获取数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataServiceTeamMethod", IsRequired = true)]
        internal string GetDataServiceTeamMethod
        {
            get { return this["GetDataServiceTeamMethod"].ToString(); }
            set { this["GetDataServiceTeamMethod"] = value; }
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
        /// 判断业主是否存在方法名
        /// </summary>
        [ConfigurationProperty("IsExist_serviceteamnameMethod", IsRequired = true)]
        internal string IsExist_serviceteamnameMethod
        {
            get { return this["IsExist_serviceteamnameMethod"].ToString(); }
            set { this["IsExist_serviceteamnameMethod"] = value; }
        }

        /// <summary>
        /// 根据编号获取业主数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataByIDMethod", IsRequired = true)]
        internal string GetDataByIDMethod
        {
            get { return this["GetDataByIDMethod"].ToString(); }
            set { this["GetDataByIDMethod"] = value; }
        }
    }
}
