﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
        public int UserId { get; set; }
    }
}
