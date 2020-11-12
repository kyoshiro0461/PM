﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMModel
{
    /// <summary>
    /// 项目信息类（模型层）
    /// </summary>
    public class ProjectsTeamM
    {
        #region 变量
        private int _pt_id;                             //编号
        //private IsDisableEnum _mn_onoff;                //状态
        private string _pt_name;                        //名称
        #endregion
        #region 属性
        /// <summary>
        /// 编号
        /// </summary>
        public int PTID
        {
            get { return this._pt_id; }
            set { this._pt_id = value; }
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
        public string PTName
        {
            get { return this._pt_name; }
            set { this._pt_name = value; }
        }

        
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ProjectsTeamM()
        {
            this._pt_id = 0;
           // this._mn_onoff = IsDisableEnum.idNo;
            this._pt_name = "";
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
