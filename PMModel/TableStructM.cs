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

        #region 劳务队信息表(serviceteam)
        /// <summary>
        /// 业主信息表
        /// </summary>
        public static class Info_ServiceTeam
        {
            /// <summary>
            /// 表名
            /// </summary>
            public static string TABLENAME = "ServiceTeam";

            ///<summary>
            ///序号
            /// </summary>
            public static string ST_ID = "st_id";

            ///<summary>
            ///名称
            /// </summary>
            public static string ST_NAME = "st_name";

        }
        #endregion

        #region 供应商信息表(Suppliers)
        /// <summary>
        /// 业主信息表
        /// </summary>
        public static class Info_Suppliers
        {
            /// <summary>
            /// 表名
            /// </summary>
            public static string TABLENAME = "Suppliers";

            ///<summary>
            ///序号
            /// </summary>
            public static string SP_ID = "sp_id";

            ///<summary>
            ///名称
            /// </summary>
            public static string SP_NAME = "sp_name";

        }
        #endregion

        #region 项目信息表(Projects)
        /// <summary>
        /// 项目信息表
        /// </summary>
        public static class Info_Projects
        {
            /// <summary>
            /// 表名
            /// </summary>
            public static string TABLENAME = "Projects";

            ///<summary>
            ///序号
            /// </summary>
            public static string PR_ID = "pr_id";

            ///<summary>
            ///名称
            /// </summary>
            public static string PR_NAME = "pr_name";

            /// <summary>
            /// 归属
            /// </summary>
            public static string PR_BELONG = "pr_belong";
        }
        #endregion
        #region 合同信息表(Contract)
        /// <summary>
        /// 合同信息表
        /// </summary>
        public static class Info_Contract
        {
            /// <summary>
            /// 表名
            /// </summary>
            public static string TABLENAME = "Contract";

            ///<summary>
            ///序号
            /// </summary>
            public static string CT_ID = "ct_id";

            ///<summary>
            ///名称
            /// </summary>
            public static string CT_NAME = "ct_name";

            /// <summary>
            /// 归属
            /// </summary>
            public static string CT_BELONG = "ct_belong";
        }
        #endregion
        #region 收付款信息表(Contract)
        /// <summary>
        /// 收付款信息表
        /// </summary>
        public static class Info_Finance
        {
            /// <summary>
            /// 表名
            /// </summary>
            public static string TABLENAME = "Finance";

            ///<summary>
            ///序号
            /// </summary>
            public static string CT_ID = "sf_id";

            ///<summary>
            ///名称
            /// </summary>
            public static string CT_NAME = "sf_name";

            /// <summary>
            /// 归属
            /// </summary>
            public static string CT_BELONG = "sf_belong";
        }
        #endregion
    }
}
