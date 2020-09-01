using PMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDAL.Instance
{
    /// <summary>
    /// 收付款信息接口（数据链路层）
    /// </summary>
    public interface IFinanceD
    {
        /// <summary>
        /// 收付款信息类（模型层）
        /// </summary>
        FinanceM Infomation_finance { set; }

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        bool Save();

        /// <summary>
        /// 删除收付款信息(Ower页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        int Del_Finance();
        
        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        int Update();
    }
}
