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
    /// 收付款配置节点
    /// </summary>
    internal class FinanceSection : InstanceSection
    {
        /// <summary>
        /// 获取数据方法名
        /// </summary>
        [ConfigurationProperty("GetDataFinanceMethod", IsRequired = true)]
        internal string GetDataFinanceMethod
        {
            get { return this["GetDataFinanceMethod"].ToString(); }
            set { this["GetDataFinanceMethod"] = value; }
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
        /// 判断收付款是否存在方法名
        /// </summary>
        [ConfigurationProperty("IsExist_financenameMethod", IsRequired = true)]
        internal string IsExist_financenameMethod
        {
            get { return this["IsExist_financenameMethod"].ToString(); }
            set { this["IsExist_financenameMethod"] = value; }
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
