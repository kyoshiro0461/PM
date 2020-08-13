using PMDAL.Instance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMBLL.Instance
{
    /// <summary>
    /// 链接接口（业务逻辑层）
    /// </summary>
    public interface IConnectionB
    {
        /// <summary>
        /// 链接类（数据链路层）
        /// </summary>
        IConnectionD ConnectionD { get; }
    }
}
