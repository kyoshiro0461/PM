using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMModel
{
    /// <summary>
    /// 后台菜单信息类（模型层）
    /// </summary>
    public class MenuM
    {
        #region 变量
        private int _mn_id;                             //菜单编号
        private int _mn_tid;                            //顶级菜单编号
        //private IsDisableEnum _mn_onoff;                //状态
        private int _mn_pid;                            //父级菜单编号
        private string _mn_name;                        //菜单名称
        private string _mn_link;                        //链接
        private int _mn_order;                          //排序
        private int _mn_level;                          //级别
       
        

        #endregion
        #region 属性
        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MNID
        {
            get { return this._mn_id; }
            set { this._mn_id = value; }
        }
        /// <summary>
        /// 顶级菜单编号
        /// </summary>
        public int MNTID
        {
            get { return this._mn_tid; }
            set { this._mn_tid = value; }
        }
        /// <summary>
        /// 父级菜单编号
        /// </summary>
        public int MNPID
        {
            get { return this._mn_pid; }
            set { this._mn_pid = value; }
        }
        /// <summary>
        /// 是否被禁用
        /// </summary>
        //public IsDisableEnum OnOff
        //{
        //    get { return this._mn_onoff; }
        //}
       

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name
        {
            get { return this._mn_name; }
            set { this._mn_name = value; }
        }
        /// <summary>
        ///链接
        /// </summary>
        public string Link
        {
            get { return this._mn_link; }
            set { this._mn_link = value; }
        }
        /// <summary>
        ///排序
        /// </summary>
        public int Order
        {
            get { return this._mn_order; }
            set { this._mn_order = value; }
        }
        /// <summary>
        ///级别
        /// </summary>
        public int Level
        {
            get { return this._mn_level; }
            set { this._mn_level = value; }
        }
       


        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public MenuM()
        {
            this._mn_id = 0;
            this._mn_tid = 0;
            this._mn_pid = 0;
           // this._mn_onoff = IsDisableEnum.idNo;
            this._mn_name = "";
            this._mn_link = "";
            this._mn_order = 0;
            this._mn_level = 0;
          
           

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
