/*
* Copyright (c) 2015,上海汇航捷讯网络科技有限公司
* All rights reserved.
* 
* 摘    要：
*
* 当前版本：1.0
* 作    者：Gondar
* 创建日期：2016/4/20 19:18:54
*
* 修改记录：
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapQueen.Cache.V1
{
    public class CacheHelperV1 : ICacheHelperV1
    {
        public void Set<T>(string key, T obj)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
