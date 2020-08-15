using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMModel;
using PMBLL.Instance;
using PMDAL.Instance;

namespace PMBLL.Instance
{
    /// <summary>
    /// 用户类（业务逻辑层）
    /// </summary>
    public class MenuB : IMenuB
    {
        #region 常量
        const string GROUPNAME = "MenuGroup";                               //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                           //Section名称
        #endregion
        #region 变量
        private IMenuB _menud;                                          //后台菜单信息类（数据链路层）
        private MenuM _menum;                                           //后台菜单信息类（模型层）
        private IConnectionB _connectionb;                              //链接类（业务逻辑层）
        #endregion
        #region 属性
        /// <summary>
        /// 后台菜单信息类（模型层）
        /// </summary>
        public MenuM Infomation_menu
        {
            get { return this._menum; }
            set { this._menum = value; }
        }

        MenuM IMenuB.Infomation_menu
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionb">链接类</param>
        public MenuB(IConnectionB connectionb)
        {
            this._connectionb = connectionb;
            InitObject();//初始化对象
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">后台菜单信息类（模型层）</param>
        /// <param name="connectionb">链接类</param>
        public MenuB(MenuM info, IConnectionB connectionb)
            : this(connectionb)
        {
            this.Infomation_menu = info;
        }
        #endregion
        #region 方法
        /// <summary>
        /// 初始化对象
        /// </summary>
        void InitObject()
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
            string configPath = Common.CommonMethods.GetConfigPath();
            //读取配置文件的信息
            Sections.MenuSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.MenuSection;
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
            this._menud = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionb.ConnectionD }) as IMenuB;
        }

        public List<IMenuB> GetDataMenu()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
