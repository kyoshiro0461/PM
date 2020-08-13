using PMDAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDAL.Instance
{
    /// <summary>
    /// 链接接口（数据链路层）
    /// </summary>
    public interface IConnectionD
    {
        /// <summary>
        /// 数据库工厂类
        /// </summary>
        DbFactoryD DataBaseFactory { get; }
    }
}
