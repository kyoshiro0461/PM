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
    /// 业主信息类（业务逻辑层）
    /// </summary>
    public class OwerB : IOwerB
    {
        #region 常量
        const string GROUPNAME = "OwerGroup";                           //SectionGroup名称
        const string SECTIONNAME = "SetInstance";                       //Section名称
        #endregion
        #region 变量
        private IOwerD _owerd;                                         //业主信息类（数据链路层）
        private string _methodnm_GetDefaultOwer;                       //GetDefaultOwer方法名
        private string _methodnm_GetPageData;                          //GetPageData
        private string _methodnm_IsExist_owername;                    //IsExist_owername方法名
        private IConnectionB _connectionb;                            //链接类（业务逻辑层）
        private OwerM _owerm;                                         //业主信息类（模型层）
        private string _methodnm_GetDataByID;                         //GetDataByID方法名
        public OwerM Infomation_ower
        {
            get { return this._owerm; }
            set { this._owerm = value; this._owerd.Infomation_ower = this._owerm; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connectionb">链接类</param>
        public OwerB(IConnectionB connectionb)
        {
            this._connectionb = connectionb;
            InitObject();//初始化对象
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info">用户信息类（模型层）</param>
        /// <param name="connectionb">链接类</param>
        public OwerB(OwerM info, IConnectionB connectionb)
            : this(connectionb)
        {
            this.Infomation_ower = info;
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
            Sections.OwerSection section = PublicMethods.Methods.ReadConfigFile_SectionGroup(configPath, GROUPNAME, SECTIONNAME) as Sections.OwerSection;
            if (section != null)
            {
                strNameSpace = section.NameSpace;//命名空间
                strInstance = section.Instance;//实例
                this._methodnm_GetDefaultOwer = section.GetDataOwerMethod;   //GetDefaultOwer方法名
                this._methodnm_GetPageData = section.GetPageDataMethod;
                this._methodnm_IsExist_owername = section.IsExist_owernameMethod;//IsExist_owername方法名
                this._methodnm_GetDataByID = section.GetDataByIDMethod;     //GetDataByID方法名
            }
        }
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="strInstance">实例名</param>
        void InstanceObject(string strNameSpace, string strInstance)
        {
            this._owerd = PublicMethods.Methods.InstanceObject(strNameSpace, strInstance, new object[] { this._connectionb.ConnectionD }) as OwerD;
        }
        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="lstOwer">业主信息类（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        List<IOwerB> ConvertToOwerB(List<OwerM> lstOwer)
        {
            List<IOwerB> result = null;
            if (lstOwer != null && lstOwer.Count > 0)
            {
                result = new List<IOwerB>();
                lstOwer.ForEach(p => result.Add(new OwerB(this._connectionb) { Infomation_ower = p }));
            }
            return result;
        }
        /// <summary>
        /// 获取业主集合数据
        /// </summary>
        /// <param >获取Ower表集合数据</param>
        /// <returns>分类信息（业务逻辑层）集合</returns>
        public List<IOwerB> GetDataOwer()
        {
            //通过反射调用数据链路层的分类信息集合
            List<OwerM> lstOwer = Methods.ReflexInvokeMethod(this._owerd, this._methodnm_GetDefaultOwer, new Type[] { typeof(IConnectionD) }, new object[] { this._connectionb.ConnectionD }) as List<OwerM>;
            if (lstOwer != null && lstOwer.Count > 0) lstOwer = lstOwer.Where(p => true).ToList();
            return ConvertToOwerB(lstOwer);
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
            object[] args = new object[] { count, start, size, key, order, orderway, this._connectionb.ConnectionD };
            List<OwerM> lstower = Methods.ReflexInvokeMethod(this._owerd, this._methodnm_GetPageData, new Type[] { typeof(long).MakeByRefType(), typeof(long), typeof(int), typeof(string), typeof(string), typeof(OrderType), typeof(IConnectionD) }, args) as List<OwerM>;
            count = args[0].ConvertToInt64();
            return ConvertToOwerB(lstower);
        }
        /// <summary>
        /// 判断业主是否存在
        /// </summary>
        /// <param name="owername">业主名</param>
        /// <returns>业主信息类</returns>
        public OwerM IsExist_owername(string owername)
        {
            //通过反射调用数据链路层的用户类IsExist_username判断用户是否存在
            return Methods.ReflexInvokeMethod(this._owerd, this._methodnm_IsExist_owername, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { owername, this._connectionb.ConnectionD }) as OwerM;
        }

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        public bool Save()
        {
            return this._owerd.Save();//存档
        }

        /// <summary>
        /// 删除业主信息(Ower页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        public int Del_Ower()
        {
            return this._owerd.Del_Ower();
        }

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>数据</returns>
        public IOwerB GetDataByID(string id)
        {
            OwerM result = Methods.ReflexInvokeMethod(this._owerd, this._methodnm_GetDataByID, new Type[] { typeof(String), typeof(IConnectionD) }, new object[] { id, this._connectionb.ConnectionD }) as OwerM;
            return ConvertToOwer_B(result);
        }

        /// <summary>
        /// 转换成业务逻辑层的对象
        /// </summary>
        /// <param name="ower">业主信息（模型层）</param>
        /// <returns>（业务逻辑层）对象</returns>
        IOwerB ConvertToOwer_B(OwerM owerm)
        {
            IOwerB result = null;
            if (owerm != null)
            {
                result = new OwerB(owerm, this._connectionb);
            }
            return result;
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        public bool Update()
        {
            int effect = this._owerd.Update();
            return (effect > 0);
        }
        #endregion

    }
}
