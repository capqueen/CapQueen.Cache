/*
* Copyright (c) 2015,CapQueen
* All rights reserved.
* 
* 摘    要：
*
* 当前版本：1.0
* 作    者：CapQueen
* 创建日期：2016/4/20 19:31:42
*
* 修改记录：
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Caching;

namespace CapQueen.Cache.V2
{
    public class CacheHelperV2 : ICacheHelperV2
    {
        protected static volatile ObjectCache Cache = MemoryCache.Default;

        public void Set<T>(string key, T obj)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key, Func<T> fetch = null)
        {
            T result = default(T);

            var obj = Cache.Get(key);
            if (obj is T)
            {
                result = (T)obj;
            }

            if(result == null)
            {
                result = fetch();

                if (result != null)
                    Set(key, result);
            }

            return result;
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
