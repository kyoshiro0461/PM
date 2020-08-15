using PMDAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDAL.Instance
{
    /// <summary>
    /// 链接类（数据链路层）
    /// </summary>
    public class ConnectionD : IConnectionD
    {
        #region 变量
        /// <summary>
        /// 数据库工厂类
        /// </summary>
        private DbFactoryD _dbfactory;
        #endregion
        #region 属性
        /// <summary>
        /// 数据库工厂类
        /// </summary>
        public DbFactoryD DataBaseFactory
        {
            get { return this._dbfactory; }
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public ConnectionD()
        {
            this._dbfactory = new DbFactoryD();
        }
        #endregion
    }
   
}
