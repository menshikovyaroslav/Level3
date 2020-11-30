﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1WPF.Models
{
    public class Server
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsSSL { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }

        public string FullAddress { get { return $"{Address}:{Port}"; } }
    }
}