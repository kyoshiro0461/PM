using PMModel;
using PMBLL.Instance;
using PM.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.Models
{
    /// <summary>
    /// 后台菜单信息工厂类（UI层）
    /// </summary>
    public class OwerFactory
    {
        #region 常量
        const string GROUPNAME = "OwerGroup";                             //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                           //Section名称
        #endregion
        #region 变量
        private IOwerB _owerb;                                        //后台菜单信息集合类（业务逻辑层） 
        private ConnectionFactory _connectionfactory;                       //链接类                       
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public OwerFactory()
        {
            this._connectionfactory = ViewMethods.GetConnection();
            InitFactory();
        }
        #endregion
        #region 方法
        /// <summary>
        /// 初始化工厂
        /// </summary>
        void InitFactory()
        {
            string strNameSpace = "", strInstance = "";
            ReadConfigFile(ref strNameSpace, ref strInstance);//读取配置文件
            InstanceObject(strNameSpace, strInstance);//实例化对象
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="strNameSpace">返回 命名空间字符串</param>
        /// <param name="strInstance">返回 实例字符串</param>
        void ReadConfigFile(ref string strNameSpace, ref string strInstance)
        {
            string configPath = Methods.CommonMethods.GetConfigPath();
            //读取配置文件的信息
            Sections.OwerSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.OwerSection;
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
            this._owerb = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionfactory.ConnectionB }) as IOwerB;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>后台菜单信息（业务逻辑层）集合</returns>
        public List<IOwerB> GetDataOwer()
        {
            return this._owerb.GetDataOwer();
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="count">总共数据</param>
        /// <param name="start">起始数据</param>
        /// <param name="size">显示笔数</param>
        /// <param name="orderway">排序方式</param>
        /// <param name="key">搜索条件</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public  List<IOwerB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway)
        {
            return this._owerb.GetPageData(ref count, start, size, key, order, orderway);
        }
        #endregion
    }
}