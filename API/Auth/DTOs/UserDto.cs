﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Auth.DTOs
{
    public class UserDto
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}