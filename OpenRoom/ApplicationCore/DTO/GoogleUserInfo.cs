﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO
{
    public class GoogleUserInfo
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool Verified_email { get; set; }
        public string Name { get; set; }
        public string Given_name { get; set; }
        public string Family_name { get; set; }
        public string Picture { get; set; }
        public string Locale { get; set; }
        public string AccessToken { get; set; }
    }
}
