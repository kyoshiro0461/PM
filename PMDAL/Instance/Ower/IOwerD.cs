using PMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDAL.Instance
{
    /// <summary>
    /// 业主信息接口（数据链路层）
    /// </summary>
    public interface IOwerD
    {
        /// <summary>
        /// 业主信息类（模型层）
        /// </summary>
        OwerM Infomation_ower { set; }
    }
}
