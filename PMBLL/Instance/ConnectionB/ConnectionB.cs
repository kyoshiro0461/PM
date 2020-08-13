using PMDAL.Instance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMBLL.Instance
{
    /// <summary>
    /// 链接类（业务逻辑层）
    /// </summary>
    public class ConnectionB : IConnectionB
    {
        #region 常量
        const string GROUPNAME = "ConnectionGroup";                         //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                           //Section名称
        #endregion
        #region 变量
        private IConnectionD _connectiond;                              //链接类（数据链路层）
        #endregion
        #region 属性
        /// <summary>
        /// 链接类（数据链路层）
        /// </summary>
        public IConnectionD ConnectionD
        {
            get { return this._connectiond; }
        }
        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public ConnectionB()
        {
            InitObject();
        }
        #endregion
        #region 方法
        /// <summary>
        /// 初始化对象
        /// </summary>
        void InitObject()
        {
            string strNameSpace = "", strInstance = "";
            ReadConfigFile(ref strNameSpace, ref strInstance);
            InstanceObject(strNameSpace, strInstance);//实例化对象
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="strNameSpace">返回 命名空间字符串</param>
        /// <param name="strInstance">返回 实例字符串</param>
        void ReadConfigFile(ref string strNameSpace, ref string strInstance)
        {
            string configPath = Common.CommonMethods.GetConfigPath();
            //读取配置文件的信息
            Sections.ConnectionSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.ConnectionSection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
            }
        }
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="strInstance">实例名</param>
        void InstanceObject(string strNameSpace, string strInstance)
        {
            this._connectiond = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance) as IConnectionD;
        }
        #endregion
    }
}
