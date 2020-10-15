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
    public class QuantityM
    {
        #region 变量
        private int _qt_id;          //编号
        private int _qt_prid;        //对应的项目编号
        private int _qt_cnid;        //对应的合同编号
        private int _qt_clid;        //对应的往来客户编号
        private string _qt_content;  //施工内容
        private string _qt_measurement;   //计量单位
        private decimal _qt_quantity;   //工程量
        private decimal _qt_price;      //单价
        private decimal _qt_money;      //金额
        #endregion
        #region 属性
        /// <summary>
        /// 编号
        /// </summary>
        public int QTID
        {
            get { return this._qt_id; }
            set { this._qt_id = value; }
        }
        
        /// <summary>
        /// 对应的项目编号
        /// </summary> 
        public int QTPRID
        {
            get { return this._qt_prid; }
            set { this._qt_prid = value; }
        }
        
        /// <summary>
        /// 对应的合同编号
        /// </summary>
        public int QTCNID
        {
            get { return this._qt_cnid; }
            set { this._qt_cnid = value; }
        }

        /// <summary>
        /// 对应的往来客户编号
        /// </summary> 
        public int QTCLID
        {
            get { return this._qt_clid; }
            set { this._qt_clid = value; }
        } 

        /// <summary>
        /// 施工内容
        /// </summary>
        public string QTCONTENT
        {
            get { return this._qt_content; }
            set { this._qt_content = value; }
        }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string QTMEASUREMENT
        {
            get { return this._qt_measurement; }
            set { this._qt_measurement = value; }
        }

        /// <summary>
        /// 工程量
        /// </summary>
        public decimal QTQUANTITY
        {
            get { return this._qt_quantity; }
            set { this._qt_quantity = value; }
        }

        /// <summary>
        /// 单价
        /// </summary> 
        public decimal QTPRICE
        {
            get { return this._qt_price; }
            set { this._qt_price = value; }
        }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal QTMONEY
        {
            get { return this._qt_money; }
            set { this._qt_money = value; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public QuantityM()
        {
            this._qt_id = 0;
            this._qt_prid = -1;
            this._qt_cnid = -1;
            this._qt_clid = -1;
            this._qt_content = null;
            this._qt_measurement = null;
            this._qt_quantity = 0;
            this._qt_price = 0;
            this._qt_money = 0;
       }
        #endregion
        #region 方法
        
        
        #endregion
    }
}
