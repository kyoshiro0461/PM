using PMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDAL.Instance
{
    /// <summary>
    /// 后台菜单信息接口（数据链路层）
    /// </summary>
    public interface IMenuD
    {
        /// <summary>
        /// 后台菜单信息类（模型层）
        /// </summary>
        MenuM Infomation_menu { set; }
    }
}
