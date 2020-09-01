using PMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDAL.Instance
{
    /// <summary>
    /// 合同信息接口（数据链路层）
    /// </summary>
    public interface IContractD
    {
        /// <summary>
        /// 合同信息类（模型层）
        /// </summary>
        ContractM Infomation_contract { set; }

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        bool Save();

        /// <summary>
        /// 删除合同信息(Ower页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        int Del_Contract();
        
        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        int Update();
    }
}
