using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMModel
{
    /// <summary>
    /// 表结构类（模型层）
    /// </summary>
    public static class TableStructM
    {
        #region 菜单信息表(info_menu)
        /// <summary>
        /// 菜单信息表
        /// </summary>
        public static class Info_Menu
        {
            /// <summary>
            /// 表名
            /// </summary>
            public static string TABLENAME = "Menu";
            /// <summary>
            /// 菜单编号
            /// </summary>
            public static string MN_ID = "mn_id";
            /// <summary>
            /// 顶级菜单编号
            /// </summary>
            public static string MN_TID = "mn_tid";
            /// <summary>
            /// 父级菜单编号
            /// </summary>
            public static string MN_PID = "mn_pid";
            /// <summary>
            /// 菜单名称
            /// </summary>
            public static string MN_NAME = "mn_name";
            /// <summary>
            /// 链接
            /// </summary>
            public static string MN_LINK = "mn_link";
            /// <summary>
            /// 排序
            /// </summary>
            public static string MN_ORDER = "mn_order";
            /// <summary>
            /// 级别
            /// </summary>
            public static string MN_LEVEL = "mn_level";
            /// <summary>
            /// 状态
            /// </summary>
            public static string MN_ONOFF = "mn_onoff";
            
        }
        #endregion

        #region 业主信息表(info_ower)
        /// <summary>
        /// 业主信息表
        /// </summary>
        public static class Info_Ower
        {
            /// <summary>
            /// 表名
            /// </summary>
            public static string TABLENAME = "Ower";

            ///<summary>
            ///序号
            /// </summary>
            public static string OW_ID = "ow_id";

            ///<summary>
            ///名称
            /// </summary>
            public static string OW_NAME = "ow_name";

        }
        #endregion
    }
}
