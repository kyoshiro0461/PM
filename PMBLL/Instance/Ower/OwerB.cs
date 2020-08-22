﻿using System;
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
        const string SECTIONNAME = "SetInstance";                           //Section名称
        #endregion
        #region 变量
        private IOwerD _owerd;                                                  //业主信息类（数据链路层）
        private string _methodnm_GetDefaultOwer;                                //GetDefaultOwer方法名
        private string _methodnm_GetPageData;                           //GetPageData
        private IConnectionB _connectionb;                                      //链接类（业务逻辑层）
        private OwerM _owerm;                                           //业主信息类（模型层）
        public OwerM Infomation_ower
        {
            get { return this._owerm; }
            set { this._owerm = value; }
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
        /// <param name="lstOwer">后台菜单信息类（模型层）</param>
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

        #endregion

    }
}