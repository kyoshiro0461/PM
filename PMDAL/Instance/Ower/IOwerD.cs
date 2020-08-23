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

        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="userm">业主信息类（模型层）</param>
        /// <returns>T=存档成功；F=存档失败</returns>
        bool Save();
    }
}
