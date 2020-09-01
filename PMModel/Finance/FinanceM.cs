using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMModel
{
    /// <summary>
    /// 收付款信息类（模型层）
    /// </summary>
    public class FinanceM
    {
        #region 变量
        private int _sf_id;                             //编号
        //private IsDisableEnum _mn_onoff;                //状态
        private string _sf_name;                        //名称
        private string _sf_belong;                      //隶属关系
        #endregion
        #region 属性
        /// <summary>
        /// 编号
        /// </summary>
        public int SFID
        {
            get { return this._sf_id; }
            set { this._sf_id = value; }
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
        public string SFName
        {
            get { return this._sf_name; }
            set { this._sf_name = value; }
        }

        /// <summary>
        /// 隶属关系
        /// </summary>
        public string SFBelong
        {
            get { return this._sf_belong; }
            set { this._sf_belong = value; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public FinanceM()
        {
            this._sf_id = 0;
           // this._mn_onoff = IsDisableEnum.idNo;
            this._sf_name = "";
            this._sf_belong = "";
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
