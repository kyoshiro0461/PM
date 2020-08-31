using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMModel
{
    /// <summary>
    /// 是否枚举
    /// </summary>
    public enum YesNoEnum
    {
        /// <summary>
        /// 无状态
        /// </summary>
        ynNone = -1,
        /// <summary>
        /// 否
        /// </summary>
        ynNo = 0,
        /// <summary>
        /// 是
        /// </summary>
        ynYes = 1,
    }
    /// <summary>
    /// 是否禁用枚举（0=禁用；1=使用；2=已删除）
    /// </summary>
    public enum IsDisableEnum
    {
        /// <summary>
        /// 禁用
        /// </summary>
        idYes = 0,
        /// <summary>
        /// 未禁用
        /// </summary>
        idNo = 1,
        /// <summary>
        /// 已删除
        /// </summary>
        idDel = 2,
    }

    /// <summary>
    /// 排序类型
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// 升序
        /// </summary>
        otAsc = 0,
        /// <summary>
        /// 降序
        /// </summary>
        otDesc = 1,
    }

    

}
