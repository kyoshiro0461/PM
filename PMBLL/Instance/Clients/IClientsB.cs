using PMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMBLL.Instance
{
    /// <summary>
    /// 客户信息接口（业务逻辑层）
    /// </summary>
    public interface IClientsB
    {
        #region 属性
        /// <summary>
        /// 客户信息类（模型） 
        ////</summary>
        ClientsM Infomation_clients { get; set; }
        #endregion
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>业主信息（业务逻辑层）集合</returns>
        List<IClientsB> GetDataClients();
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
        List<IClientsB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway, string belong);

        /// <summary>
        /// 判断客户是否存在
        /// </summary>
        /// <param name="clientsname">客户名</param>
        /// <returns>客户信息类</returns>
        ClientsM IsExist_clientsname(string clientsname, string id);

        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="clientsm">客户信息类（模型层）</param>
        /// <returns>T=存档成功；F=存档失败</returns>
        bool Save();

        /// <summary>
        /// 删除客户信息(clients页面)
        /// </summary>
        /// <returns>受影响的行数</returns>
        int Del_Clients();

        /// <summary>
        /// 通过编号获取数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>数据</returns>
        IClientsB GetDataByID(string id);

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <returns>受影响的行数</returns>
        bool Update();
    }
}
