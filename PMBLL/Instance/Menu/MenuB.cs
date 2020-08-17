using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMModel;
using PMBLL.Instance;
using PMDAL.Instance;
using PublicMethods;

namespace PMBLL.Instance
{
    /// <summary>
    /// 后台菜单信息类（业务逻辑层）
    /// </summary>
    public class MenuB : IMenuB
    {
        #region 常量
        const string GROUPNAME = "MenuGroup";                           //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                           //Section名称
        #endregion
        #region 变量
        private IMenuD _menud;                                                  //单篇信息类（数据链路层）
        private string _methodnm_GetDefaultMenu;                                //GetDefaultMenu方法名
        private IConnectionB _connectionb;                                      //链接类（业务逻辑层）
        private MenuM _menum;                                           //后台菜单信息类（模型层）
        public MenuM Infomation_menu
        {
            get { return this._menum; }
            set { this._menum = value; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectionb">链接类</param>
        public MenuB(IConnectionB connectionb)
        {
            this._connectionb = connectionb;
            InitObject();//初始化对象
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
            Sections.MenuSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.MenuSection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
                this._methodnm_GetDefaultMenu = section.GetDataMenuMethod;   //GetDefaultMenu方法名
            }
        }
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="strInstance">实例名</param>
        void InstanceObject(string strNameSpace, string strInstance)
        {
            this._menud = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionb.ConnectionD }) as MenuD;
        }
        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="lstMenu">后台菜单信息类（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        List<IMenuB> ConvertToMenuB(List<MenuM> lstMenu)
        {
            List<IMenuB> result = null;
            if (lstMenu != null && lstMenu.Count > 0)
            {
                result = new List<IMenuB>();
                lstMenu.ForEach(p => result.Add(new MenuB(this._connectionb) { Infomation_menu = p }));
            }
            return result;
        }
        /// <summary>
        /// 获取后台菜单集合数据
        /// </summary>
        /// <param >获取menu表集合数据</param>
        /// <returns>分类信息（业务逻辑层）集合</returns>
        public List<IMenuB> GetDataMenu()
        {
            //通过反射调用数据链路层的分类信息集合
            List<MenuM> lstMenu = Methods.ReflexInvokeMethod(this._menud, this._methodnm_GetDefaultMenu, new Type[] { typeof(IConnectionD) }, new object[] { this._connectionb.ConnectionD }) as List<MenuM>;
            if (lstMenu != null && lstMenu.Count > 0) lstMenu = lstMenu.Where(p => true).ToList();
            return ConvertToMenuB(lstMenu);
        }

        
        #endregion

    }
}
