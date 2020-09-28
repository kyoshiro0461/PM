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

        #region 往来客户信息表(Clients)
        /// <summary>
        /// 业主信息表
        /// </summary>
        public static class Info_Clients
        {
            /// <summary>
            /// 表名
            /// </summary>
            public static string TABLENAME = "Clients";

            ///<summary>
            ///序号
            /// </summary>
            public static string CL_ID = "cl_id";

            ///<summary>
            ///名称
            /// </summary>
            public static string CL_NAME = "cl_name";

            ///<summary>
            ///联系人
            /// </summary>
            public static string CL_PERSON = "cl_person";

            ///<summary>
            ///联系方式
            /// </summary>
            public static string CL_TEL = "cl_tel";

            ///<summary>
            ///地址
            /// </summary>
            public static string CL_ADDRESS = "cl_address";

            ///<summary>
            ///社会统一信用代码
            /// </summary> 
            public static string CL_CODE = "cl_code";

            ///<summary>
            ///开户行
            /// </summary>
            public static string CL_BANK = "cl_bank";

            ///<summary>
            ///账号
            /// </summary>
            public static string CL_ACCOUNT = "cl_account";

            ///<summary>
            ///隶属，0=业主，1=施工队，2=供应商
            /// </summary>
            public static string CL_BELONG = "cl_belong";

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
            ///项目编号
            /// </summary>
            public static string CT_PRID = "ct_prid";
            
            ///<summary>
            ///名称
            /// </summary>
            public static string CT_NAME = "ct_name";
           
            ///<summary>
            ///编号
            /// </summary>
            public static string CT_NO = "ct_no";

            ///<summary>
            ///往来客户编号
            /// </summary>
            public static string CT_CLID = "ct_clid";

            ///<summary>
            ///金额
            /// </summary>
            public static string CT_MONEY = "ct_money";

            ///<summary>
            ///签订日期
            /// </summary>
            public static string CT_DATE = "ct_date";

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
            public static string SF_ID = "sf_id";

            ///<summary>
            ///名称
            /// </summary>
            public static string SF_NAME = "sf_name";

            /// <summary>
            /// 归属
            /// </summary>
            public static string SF_BELONG = "sf_belong";
        }
        #endregion
    }
}
