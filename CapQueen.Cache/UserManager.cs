
/*
* Copyright (c) 2015,CapQueen
* All rights reserved.
* 
* 摘    要：
*
* 当前版本：1.0
* 作    者：CapQueen
* 创建日期：2016/4/20 19:18:19
*
* 修改记录：
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CapQueen.Cache.V1;
using CapQueen.Cache.Model;
using CapQueen.Cache.Repository;
using CapQueen.Cache.V2;

namespace CapQueen.Cache
{
    public class UserManager
    {
        private ICacheHelperV1 _cacheHelper = new CacheHelperV1();
        private const string USER_CACHE_KEY = "urn:user:{0}";
        private UserRepository _repository = new UserRepository();
        private ICacheHelperV2 _cacheHelperV2 = new CacheHelperV2();

        public User Get(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            var key = string.Format(USER_CACHE_KEY, id);
            var user = _cacheHelper.Get<User>(key);
            if (user != null)
                return user;

            return _repository.Get(id);
        }

        public User GetV2(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            var key = string.Format(USER_CACHE_KEY, id);
            var user = _cacheHelper.Get<User>(key);
            if (user != null)
                return user;

            user = _repository.Get(id);
            if (user != null)
                _cacheHelper.Set(key, user);

            return user;
        }

        public User GetV3(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("id");

            var key = string.Format(USER_CACHE_KEY, id);
            return _cacheHelperV2.Get<User>(key, () => _repository.Get(id));            
        }
    }
}
