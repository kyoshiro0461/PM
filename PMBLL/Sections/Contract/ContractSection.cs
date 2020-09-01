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
    /// 合同配置节点
    /// </summary>
    internal class ContractSection : InstanceSection
    {
        /// <summary>
        /// 获取数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataContractMethod", IsRequired = true)]
        internal string GetDataContractMethod
        {
            get { return this["GetDataContractMethod"].ToString(); }
            set { this["GetDataContractMethod"] = value; }
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
        /// 判断合同是否存在方法名
        /// </summary>
        [ConfigurationProperty("IsExist_contractnameMethod", IsRequired = true)]
        internal string IsExist_contractnameMethod
        {
            get { return this["IsExist_contractnameMethod"].ToString(); }
            set { this["IsExist_contractnameMethod"] = value; }
        }

        /// <summary>
        /// 根据编号获取合同数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataByIDMethod", IsRequired = true)]
        internal string GetDataByIDMethod
        {
            get { return this["GetDataByIDMethod"].ToString(); }
            set { this["GetDataByIDMethod"] = value; }
        }
    }
}
