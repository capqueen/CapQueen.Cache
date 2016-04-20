using CapQueen.Cache.Model;
/*
* Copyright (c) 2015,CapQueen
* All rights reserved.
* 
* 摘    要：
*
* 当前版本：1.0
* 作    者：CapQueen
* 创建日期：2016/4/20 19:25:56
*
* 修改记录：
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapQueen.Cache.Repository
{
    public class UserRepository 
    {
        public User Get(int id)
        {
            return new User
            {
                UserName = "CapQueen",
                Cellphone = "18667373058",
                UserId = 1
            };
        }
    }
}
