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
    public class ProjectsTeamM
    {
        #region 变量
        private int _pt_id;                             //编号
        private string _pt_name;                        //名称
        private int _pt_tid;                            //顶级项目组编号
        private int _pt_pid;                            //父级项目组编号                            
        private int _pt_order;                          //排序
        private int _pt_level;                          //级别
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
        /// 名称
        /// </summary>
        public string PTName
        {
            get { return this._pt_name; }
            set { this._pt_name = value; }
        }

        /// <summary>
        /// 顶级项目组编号
        /// </summary>
        public int PTTid
        {
            get { return this._pt_tid; }
            set { this._pt_tid = value; }
        }

        /// <summary>
        /// 父级项目组编号
        /// </summary>
        public int PTPid
        {
            get { return this._pt_pid; }
            set { this._pt_pid = value; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int PTOrder
        {
            get { return this._pt_order; }
            set { this._pt_order = value; }
        }

        /// <summary>
        /// 级别
        /// </summary>
        public int PTLevel
        {
            get { return this._pt_level; }
            set { this._pt_level = value; }
        }
        #endregion
      
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ProjectsTeamM()
        {
            this._pt_id = 0;
            this._pt_name = "";
            this._pt_level = 0;
            this._pt_order = 0;
            this._pt_pid = 0;
            this._pt_tid = 0;
       }
        #endregion
    }
}
