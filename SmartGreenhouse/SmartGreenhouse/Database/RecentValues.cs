using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartGreenhouse.Database
{
    public partial class RecentValues
    {
        public int Id { get; set; }
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public double? HeatIndex { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? InsertDate { get; set; }
        public double? Luminosity { get; set; }

    }
}
