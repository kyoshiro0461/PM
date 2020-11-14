using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMModel
{
    /// <summary>
    /// 项目信息类（模型层）
    /// </summary>
    public class ProjectsM
    {
        #region 变量
        private int _pr_id;                             //编号
        //private IsDisableEnum _mn_onoff;                //状态
        private string _pr_name;                        //名称
        private string _pr_belong;                      //隶属关系
        private string _pr_ptid;
        #endregion
        #region 属性
        /// <summary>
        /// 编号
        /// </summary>
        public int PRID
        {
            get { return this._pr_id; }
            set { this._pr_id = value; }
        }
        /// <summary>
        /// 是否被禁用
        /// </summary>
        //public IsDisableEnum OnOff
        //{
        //    get { return this._mn_onoff; }
        //}
       

        /// <summary>
        /// 名称
        /// </summary>
        public string PRName
        {
            get { return this._pr_name; }
            set { this._pr_name = value; }
        }

        /// <summary>
        /// 隶属关系
        /// </summary>
        public string PRBelong
        {
            get { return this._pr_belong; }
            set { this._pr_belong = value; }
        }

        public string PRPtid
        {
            get { return this._pr_ptid; }
            set { this._pr_ptid = value; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ProjectsM()
        {
            this._pr_id = 0;
           // this._mn_onoff = IsDisableEnum.idNo;
            this._pr_name = "";
            this._pr_belong = "";
            this._pr_ptid = "";
       }
        #endregion
        #region 方法
        /// <summary>
        /// 设置是否禁用属性
        /// </summary>
        /// <param name="value">属性值</param>
        //public void SetOnOff(int value)
        //{
        //    this._mn_onoff = CommonMethods.SetOnOff(value);
        //}
        
        #endregion
    }
}
