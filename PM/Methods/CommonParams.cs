using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.Methods
{
    /// <summary>
    /// 公用参数类
    /// </summary>
    public static class CommonParams
    {
        /// <summary>
        /// 网址
        /// </summary>
        public static string Site = "";
        /// <summary>
        /// 版本号
        /// </summary>
        public static string Ver = "2.0.1";
        
        /// <summary>
        /// 初始化
        /// </summary>
        public static Initialization Init = null;
        /// <summary>
        /// 网站标题
        /// </summary>
        public static string SITETITLE = "民安创享";
        ///// <summary>
        ///// 地址集合
        ///// </summary>
        //public static List<AddressM> AddressCollect = new List<AddressM>();
        /// <summary>
        /// 面包屑集合
        /// </summary>
        //public static List<Crumb> CrumbCollect = new List<Crumb>();
        ///// <summary>
        ///// 寄语
        ///// </summary>
        //public static string MESSAGE = "";
        ///// <summary>
        ///// 是否启用支付功能
        ///// </summary>
        //public static bool ISPAY = true;
        ///// <summary>
        ///// 是否移动端使用
        ///// </summary>
        //public static bool IsMobile = false;
        /// <summary>
        /// 允许网页跳转集合
        /// </summary>
        public static List<string> JumpCollect = null;
        ///// <summary>
        ///// 密码尝试次数
        ///// </summary>
        //public const int PASSTRY = 5;
        ///// <summary>
        ///// 众筹列表编号
        ///// </summary>
        //public const string RAISEID = "147";
        #region cookies
        ///// <summary>
        ///// 验证码主键名（Cookie）
        ///// </summary>
        //public const string COOKIE_CHECKCODE = "Code";
        ///// <summary>
        ///// 手机验证码主键名（Cookie）
        ///// </summary>
        //public const string COOKIE_MOBILECHECKCODE = "MobileCode";
        ///// <summary>
        ///// 购物车产品编号（Cookie）
        ///// </summary>
        //public const string COOKIE_CART_CONTENTID = "Cart_Contentid";
        ///// <summary>
        ///// 购物车数量（Cookie）
        ///// </summary>
        //public const string COOKIE_CART_NUM = "Cart_Num";
        ///// <summary>
        ///// 短信验证码主键名（Cookie）
        ///// </summary>
        //public const string COOKIE_MESSAGECODE = "Message_Code";
        ///// <summary>
        ///// 订单号主键名（Cookie）
        ///// </summary>
        //public const string COOKIE_ORDERNO = "OrderNo";
        ///// <summary>
        ///// 用户编号主键名（Cookie）
        ///// </summary>
        //public const string COOKIE_USERID = "UserID";
        ///// <summary>
        ///// 登录地址主键名（Cookie）
        ///// </summary>
        //public const string COOKIE_LOGINIP = "LoginIP";
        ///// <summary>
        ///// 是否移动端登录主键名（Cookie）
        ///// </summary>
        //public const string COOKIE_ISMOBILE = "IsMobile";
        #endregion
        #region session
        ///// <summary>
        ///// 密码尝试次数的主键名(Session)
        ///// </summary>
        //public const string SESSION_PASSTRY = "passtry";
        ///// <summary>
        ///// 用户信息主键名（Session）
        ///// </summary>
        //public const string SESSION_USERINFO = "userinfo";
        ///// <summary>
        ///// 后台用户信息主键名（Session）
        ///// </summary>
        //public const string SESSION_ADMININFO = "admininfo";
        ///// <summary>
        ///// 地址集合主键名（Session）
        ///// </summary>
        //public const string SESSION_ADDRESSCOL = "addresscol";
        ///// <summary>
        ///// 区域主键名（Session）
        ///// </summary>
        //public const string SESSION_REGION = "Region";
        ///// <summary>
        ///// 轮播区域主键名（Session）
        ///// </summary>
        //public const string SESSION_SLIDEREGION = "SlideRegion";
        /// <summary>
        /// 数据库链接主键名（Session）
        /// </summary>
        public const string SESSION_CONNECTION = "Connection";
        #endregion
    }
}