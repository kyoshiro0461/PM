using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PM
{
    /// <summary>
    /// 初始化类
    /// </summary>
    public class Initialization
    {
         #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public Initialization()
        {
           ReadConfigProperty();//读取配置属性
        }
        /// <summary>
        /// 读取配置文件的属性
        /// </summary>
        void ReadConfigProperty()
        {
            //读取配置文件中的数据
            string configPath = Methods.CommonMethods.GetConfigPath();
            Configuration config = PublicMethods.Methods.ReadConfigFile(configPath);
            //网址
            Methods.CommonParams.Site = config.AppSettings.Settings["site"].Value.ToString();
            //版本
            Methods.CommonParams.Ver = config.AppSettings.Settings["version"].Value.ToString();
            //允许跳转网页
            //ReadAllowJumpProperty(config);
           
        }
        /// <summary>
        /// 读取允许跳转属性
        /// </summary>
        /// <param name="config">配置文件</param>
        void ReadAllowJumpProperty(Configuration config)
        {
            string allowjump = config.AppSettings.Settings["allowjump"].Value.ToString();
            Methods.CommonParams.JumpCollect = allowjump.Split('|').ToList();
        }
        #endregion
    }
}