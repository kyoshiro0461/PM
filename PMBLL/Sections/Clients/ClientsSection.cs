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
    /// 客户配置节点
    /// </summary>
    internal class ClientsSection : InstanceSection
    {
        /// <summary>
        /// 获取数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataClientsMethod", IsRequired = true)]
        internal string GetDataClientsMethod
        {
            get { return this["GetDataClientsMethod"].ToString(); }
            set { this["GetDataClientsMethod"] = value; }
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
        /// 判断客户是否存在方法名
        /// </summary>
        [ConfigurationProperty("IsExist_clientsnameMethod", IsRequired = true)]
        internal string IsExist_clientsnameMethod
        {
            get { return this["IsExist_clientsnameMethod"].ToString(); }
            set { this["IsExist_clientsnameMethod"] = value; }
        }

        /// <summary>
        /// 根据编号获取客户数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataByIDMethod", IsRequired = true)]
        internal string GetDataByIDMethod
        {
            get { return this["GetDataByIDMethod"].ToString(); }
            set { this["GetDataByIDMethod"] = value; }
        }
    }
}
