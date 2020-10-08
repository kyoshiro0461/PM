using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMModel
{
    /// <summary>
    /// 合同信息类（模型层）
    /// </summary>
    public class ContractM
    {
        #region 变量
        private int _ct_id;                             //编号
        //private IsDisableEnum _mn_onoff;                //状态
        private int _ct_prid;                        //项目ID
        private string _ct_name;                        //名称
        private string _ct_no;                          //合同编号
        private int _ct_clid;                        //客户ID
        private decimal _ct_money;                       //合同金额
        private DateTime? _ct_date;                        //签订日期 
        private string _ct_belong;                      //隶属关系
        #endregion
        #region 属性
        /// <summary>
        /// 编号
        /// </summary>
        public int CTID
        {
            get { return this._ct_id; }
            set { this._ct_id = value; }
        }
        /// <summary>
        /// 是否被禁用
        /// </summary>
        //public IsDisableEnum OnOff
        //{
        //    get { return this._mn_onoff; }
        //}
       
        /// <summary>
        /// 项目ID
        /// </summary>
        public int CTPrid
        {
            get { return this._ct_prid; }
            set { this._ct_prid = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string CTName
        {
            get { return this._ct_name; }
            set { this._ct_name = value; }
        }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string  CTNo
        {
            get { return this._ct_no; }
            set { this._ct_no = value; }
        }

        /// <summary>
        /// 客户ID
        /// </summary>
        public int CTClid
        {
            get { return this._ct_clid; }
            set { this._ct_clid = value; }
        }

        /// <summary>
        /// 合同金额
        /// </summary>
        public decimal CTMoney
        {
            get { return this._ct_money; }
            set { this._ct_money = value; }
        }

        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime? CTDate
        {
            get { return this._ct_date; }
            set { this._ct_date = value; }
        }

        /// <summary>
        /// 隶属关系
        /// </summary>
        public string CTBelong
        {
            get { return this._ct_belong; }
            set { this._ct_belong = value; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ContractM()
        {
            this._ct_id = 0;
            // this._mn_onoff = IsDisableEnum.idNo;
            this._ct_prid = 0;
            this._ct_name = "";
            this._ct_no = "";
            this._ct_clid = 0;
            this._ct_money = 0;
            this._ct_date = null;
            this._ct_belong = "";
            
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
