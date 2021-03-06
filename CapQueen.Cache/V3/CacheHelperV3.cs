﻿using CapQueen.Cache.Core;
/*
* Copyright (c) 2015,CapQueen
* All rights reserved.
* 
* 摘    要：
*
* 当前版本：1.0
* 作    者：Gondar
* 创建日期：2016/4/20 20:06:22
*
* 修改记录：
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace CapQueen.Cache.V3
{
    public class CacheHelperV3 : ICacheHelperV3
    {
        protected static volatile ObjectCache Cache = MemoryCache.Default;

        private static object LockObj = new object();
           

        public void Set<T>(string key, T obj)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(object id, Func<T> fetch = null)
        {
            var type = typeof(T);
            var key = string.Format("urn:{1}:{2}", type.Name, id.ToString());

            return Get(key, fetch);
        }

        public T Get<T>(string key, Func<T> fetch = null)
        {
            var result = GetFromCache(key);

            if (result == null)
            {
                lock (LockObj) //这里的锁 只是处于减少db访问压力的目的，分布式情况下依然有效 并发数最大 = 服务器数 这点压力对于DB不是问题
                {
                    result = GetFromCache(key);
                    if(result == null)
                    {
                        result = fetch();

                        if (result != null)
                            Set(key, result);
                    }
                }                
            }

            return result;
        }

        private T GetFromCache<T>(string key)
        {
            T result = default(T);

            var obj = Cache.Get(key);
            if (obj is T)
            {
                result = (T)obj;
            }

            return result;
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fetch"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public void Set<T>(T obj)
        {
            //此处应该被缓存
            var type = typeof(T);
            var primaryKey = type.GetProperties()
                .FirstOrDefault(t => t.GetCustomAttributes(false)
                    .Any(c => c is PrimaryKeyAttribute));
            var keyValue = primaryKey.GetValue(obj, null);           
            var key = string.Format("urn:{0}:{1}", type.Name, keyValue);

            var dt = DateTime.UtcNow.AddDays(1);//假设默认缓存1天
            var offset = new DateTimeOffset(dt);
            Cache.Set(key, obj, offset);
        }
    }
}
