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
    /// 供应商配置节点
    /// </summary>
    internal class SuppliersSection : InstanceSection
    {
        /// <summary>
        /// 获取数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataSuppliersMethod", IsRequired = true)]
        internal string GetDataSuppliersMethod
        {
            get { return this["GetDataSuppliersMethod"].ToString(); }
            set { this["GetDataSuppliersMethod"] = value; }
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
        /// 判断供应商是否存在方法名
        /// </summary>
        [ConfigurationProperty("IsExist_suppliersnameMethod", IsRequired = true)]
        internal string IsExist_suppliersnameMethod
        {
            get { return this["IsExist_suppliersnameMethod"].ToString(); }
            set { this["IsExist_suppliersnameMethod"] = value; }
        }

        /// <summary>
        /// 根据编号获取供应商数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataByIDMethod", IsRequired = true)]
        internal string GetDataByIDMethod
        {
            get { return this["GetDataByIDMethod"].ToString(); }
            set { this["GetDataByIDMethod"] = value; }
        }
    }
}
