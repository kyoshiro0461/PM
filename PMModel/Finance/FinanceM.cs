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
        private int _sf_collectpay;                      //收付款性质
        private int _sf_prid;                           //对应项目编号
        private int _sf_cnid;                           //对应合同编号
        private DateTime? _sf_date;                     //收付款日期
        private decimal _sf_money;                      //收付款金额
        private string _sf_account;                     //记账凭证编号
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
        /// 收付款性质
        /// </summary>
            public int SFCOLLECTPAY
        {
            get { return this._sf_collectpay; }
            set { this._sf_collectpay = value; }
        }

        /// <summary>
        /// 对应项目编号
        /// </summary>
        public int SFPRID
        {
            get { return this._sf_prid; }
            set { this._sf_prid = value; }
        }

        /// <summary>
        /// 对应合同编号
        /// </summary>
        public int SFCNID
        {
            get { return this._sf_cnid; }
            set { this._sf_cnid = value; }
        }

        /// <summary>
        /// 收付款日期
        /// </summary>
        public DateTime? SFDATE
        {
            get { return this._sf_date; }
            set { this._sf_date = value; }
        }

        /// <summary>
        /// 收付款金额
        /// </summary> 
        public decimal SFMONEY
        {
            get { return this._sf_money; }
            set { this._sf_money = value; }
        }

        /// <summary>
        /// 对应记账凭证编号
        /// </summary>
        public string SFACCOUNT
        {
            get { return this._sf_account; }
            set { this._sf_account = value; }
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
            this._sf_prid = 0;
            this._sf_cnid = 0;
            this._sf_date = null;
            this._sf_money = 0;
            this._sf_account = null;
            this._sf_collectpay = 0;
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
