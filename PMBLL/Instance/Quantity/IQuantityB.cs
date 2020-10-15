using PMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMBLL.Instance
{
    /// <summary>
    /// 工程量信息接口（业务逻辑层）
    /// </summary>
    public interface IQuantityB
    {
        #region 属性
        /// <summary>
        /// 工程量信息类（模型） 
        /// </summary>
        QuantityM Infomation_Quantity { get; set; }
        #endregion
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>工程量信息（业务逻辑层）集合</returns>
        List<IQuantityB> GetDataQuantity();
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="count">总共数据</param>
        /// <param name="start">起始数据</param>
        /// <param name="size">显示笔数</param>
        /// <param name="orderway">排序方式</param>
        /// <param name="key">搜索条件</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        List<IQuantityB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway);

        /// <summary>
        /// 判断工程量是否存在
        /// </summary>
        /// <param name="quantityname">工程量名</param>
        /// <returns>工程量信息类</returns>
        QuantityM IsExist_Quantityname(string quantityname);

        /// <summary>
        /// 存档
        /// </summary>
        /// <returns>T=存档成功；F=存档失败</returns>
        bool Save();

        /// <summary>
        /// 删除工程量信息(Quantity页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        int Del_Quantity();

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>数据</returns>
        IQuantityB GetDataByID(string id);

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        bool Update();
    }
}
