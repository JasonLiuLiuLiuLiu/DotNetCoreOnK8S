﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreOnK8S.Models
{
    public class BaseViewModel
    {
        public int BuildVersion { get; set; }
        public string NodeName { get; set; }
        public string PodName { get; set; }
        public string PodNameSpace { get; set; }
        public string PodIp { get; set; }
    }
}
