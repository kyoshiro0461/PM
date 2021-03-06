﻿using System;
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

            public static string PR_PTID = "pr_ptid";
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

            /// <summary>
            /// 收付款性质
            /// </summary>
            public static string SF_COLLECTPAY = "sf_collectpay";

            /// <summary>
            /// 对应项目编号
            /// </summary>
            public static string SF_PRID = "sf_prid";

            /// <summary>
            /// 对应合同编号
            /// </summary>
            public static string SF_CNID = "sf_cnid";

            /// <summary>
            /// 对应往来客户编号
            /// </summary>
            public static string SF_CLID = "sf_clid";

            /// <summary>
            /// 收付款日期
            /// </summary>
            public static string SF_DATE = "sf_date";

            /// <summary>
            /// 收付款金额
            /// </summary>
            public static string SF_MONEY = "sf_money";

            /// <summary>
            /// 记账凭证编号
            /// </summary>
            public static string SF_ACCOUNT = "sf_account";
        }
        #endregion

        #region 工程量信息表(Quantity)
        /// <summary>
        /// 工程量信息表
        /// </summary>
        public static class Info_Quantity
        {
            /// <summary>
            /// 表名
            /// </summary>
            public static string TABLENAME = "Quantity";

            ///<summary>
            ///序号
            /// </summary>
            public static string QT_ID = "qt_id";

            /// <summary>
            /// 项目编号
            /// </summary>
            public static string QT_PRID = "qt_prid";

            /// <summary>
            /// 对应合同编号
            /// </summary>
            public static string QT_CNID = "qt_cnid";

            /// <summary>
            /// 对应往来客户编号
            /// </summary>
            public static string QT_CLID = "qt_clid";

            /// <summary>
            /// 施工内容
            /// </summary>
            public static string QT_CONTENT = "qt_content";

            /// <summary>
            /// 计量单位
            /// </summary>
            public static string QT_MEASUREMENT = "qt_measurement";

            /// <summary>
            /// 工程量
            /// </summary>
            public static string QT_QUANTITY = "qt_quantity";

            /// <summary>
            /// 单价
            /// </summary>
            public static string QT_PRICE = "qt_price";

            /// <summary>
            /// 金额
            /// </summary>
            public static string QT_MONEY = "qt_money";
        }
        #endregion

        #region 项目组信息表(ProjectTeam)
        /// <summary>
        /// 项目组信息表
        /// </summary>
        public static class Info_ProjectTeam
        {
            /// <summary>
            /// 表名
            /// </summary>
            public static string TABLENAME = "ProjectTeam";

            ///<summary>
            ///项目组编号
            /// </summary>
            public static string PT_ID = "pt_id";

            /// <summary>
            /// 项目组名称
            /// </summary>
            public static string PT_NAME = "pt_name";

            /// <summary>
            /// 顶级项目组编号
            /// </summary>
            public static string PT_TID = "pt_tid";

            /// <summary>
            /// 父级项目组编号
            /// </summary>
            public static string PT_PID = "pt_pid";

            /// <summary>
            /// 项目组级别
            /// </summary>
            public static string PT_LEVEL = "pt_level";

            /// <summary>
            /// 项目组排序
            /// </summary>
            public static string PT_ORDER = "pt_order";

        }
        #endregion


    }
}
