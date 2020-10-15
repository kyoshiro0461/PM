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
    /// 工程量配置节点
    /// </summary>
    internal class QuantitySection : InstanceSection
    {
        /// <summary>
        /// 获取数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataQuantityMethod", IsRequired = true)]
        internal string GetDataQuantityMethod
        {
            get { return this["GetDataQuantityMethod"].ToString(); }
            set { this["GetDataQuantityMethod"] = value; }
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
        /// 判断工程量是否存在方法名
        /// </summary>
        [ConfigurationProperty("IsExist_quantitynameMethod", IsRequired = true)]
        internal string IsExist_quantitynameMethod
        {
            get { return this["IsExist_quantitynameMethod"].ToString(); }
            set { this["IsExist_quantitynameMethod"] = value; }
        }

        /// <summary>
        /// 根据编号获取收付款数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataByIDMethod", IsRequired = true)]
        internal string GetDataByIDMethod
        {
            get { return this["GetDataByIDMethod"].ToString(); }
            set { this["GetDataByIDMethod"] = value; }
        }
    }
}
