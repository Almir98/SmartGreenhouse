﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGreenhouse.ViewModel
{
    public class TemperatureVM
    {
        public int Id { get; set; }
        public float Temperature { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
