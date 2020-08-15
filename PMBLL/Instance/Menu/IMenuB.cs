using PMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMBLL.Instance
{
    /// <summary>
    /// 后台菜单信息接口（业务逻辑层）
    /// </summary>
    public interface IMenuB
    {
        #region 属性
        /// <summary>
        /// 后台菜单信息类（模型） 
        /// </summary>
        MenuM Infomation_menu { get; set; }
        #endregion
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>后台菜单信息（业务逻辑层）集合</returns>
        List<IMenuB> GetDataMenu();
    }
}
