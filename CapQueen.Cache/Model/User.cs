using CapQueen.Cache.Core;
/*
* Copyright (c) 2015,CapQueen
* All rights reserved.
* 
* 摘    要：
*
* 当前版本：1.0
* 作    者：CapQueen
* 创建日期：2016/4/20 19:20:31
*
* 修改记录：
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapQueen.Cache.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        [PrimaryKey]
        public int UserId { get; set;}

        public string UserName { get; set; }

        public string Cellphone { get; set; }
    }
}
