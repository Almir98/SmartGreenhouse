using System;
using System.Collections.Generic;

namespace SmartGreenhouse.Database
{
    public partial class RecentValues
    {
        public int Id { get; set; }
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public DateTime? InsertDate { get; set; }
        public double? Luminosity { get; set; }
        public bool? FanStatus { get; set; }
        public bool? WindowStatus { get; set; }
    }
}
