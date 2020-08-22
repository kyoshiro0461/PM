﻿using PMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMBLL.Instance
{
    /// <summary>
    /// 业主信息接口（业务逻辑层）
    /// </summary>
    public interface IOwerB
    {
        //#region 属性
        ///// <summary>
        ///// 业主信息类（模型） 
        ///// </summary>
        OwerM Infomation_ower { get; set; }
        //#endregion
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>业主信息（业务逻辑层）集合</returns>
        List<IOwerB> GetDataOwer();
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
        List<IOwerB> GetPageData(ref long count, long start, int size, string key, string order, OrderType orderway);
    }
}