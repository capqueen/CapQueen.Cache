/*
* Copyright (c) 2015,CapQueen
* All rights reserved.
* 
* 摘    要：
*
* 当前版本：1.0
* 作    者：CapQueen
* 创建日期：2016/4/20 15:07:45
*
* 修改记录：
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapQueen.Cache
{
    /// <summary>
    /// 缓存接口V2 更新Get 支持自动获取数据
    /// </summary>
    public interface ICacheHelperV2
    {
        /// <summary>
        /// 新增或者更新一个缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存Key</param>
        /// <param name="obj">缓存对象</param>
        void Set<T>(string key, T obj);
        /// <summary>
        /// 从缓存里获取一个Key的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="fetch">获取数据方法</param>
        /// <returns></returns>
        T Get<T>(string key, Func<T> fetch = null);
        /// <summary>
        /// 删除一个指定的Key
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
    }
}
