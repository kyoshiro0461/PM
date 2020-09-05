using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMModel
{
    /// <summary>
    /// 客户信息类（模型层）
    /// </summary>
    public class ClientsM
    {
        #region 变量
        private int _cl_id;                             //编号
        private string _cl_name;                        //名称
        private string _cl_tel;                         //联系方式
        private string _cl_person;                      //联系人
        private string _cl_address;                     //地址
        private string _cl_code;                        //社会统一信用代码
        private string _cl_bank;                        //开户行
        private string _cl_account;                     //账号
        private int _cl_belong;                         //隶属
        #endregion
        #region 属性
        /// <summary>
        /// 编号
        /// </summary>
        public int CLID
        {
            get { return this._cl_id; }
            set { this._cl_id = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string CLNAME
        {
            get { return this._cl_name; }
            set { this._cl_name = value; }
        }

        ///<summary>
        ///联系人
        /// </summary>
        public string CLPERSON
        {
            get { return this._cl_person; }
            set { this._cl_person = value; }
        }
        ///<summary>
        ///联系方式
        /// </summary>
        public string CLTEL
        {
            get { return this._cl_tel; }
            set { this._cl_tel = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string CLADDRESS
        {
            get { return this._cl_address; }
            set { this._cl_address = value; }
        }
        /// <summary>
        /// 社会统一信用代码
        /// </summary>
        public string CLCODE
        {
            get { return this._cl_code; }
            set { this._cl_code = value; }
        }
        /// <summary>
        /// 开户行
        /// </summary>
        public string CLBANK
        {
            get { return this._cl_bank; }
            set { this._cl_bank = value; }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string CLACCOUNT
        {
            get { return this._cl_account; }
            set { this._cl_account = value; }
        }
        /// <summary>
        /// 隶属
        /// </summary>
        public int CLBELONG
        {
            get { return this._cl_belong; }
            set { this._cl_belong = value; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ClientsM()
        {
            this._cl_id = 0;
            this._cl_name = "";
            this._cl_account = "";
            this._cl_address = "";
            this._cl_bank = "";
            this._cl_belong = 0;
            this._cl_code = "";
            this._cl_person = "";
            this._cl_tel = "";
       }
        #endregion
        
    }
}
