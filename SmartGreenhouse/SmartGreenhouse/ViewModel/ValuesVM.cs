using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGreenhouse.ViewModel
{
    public class ValuesVM
    {
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public double? HeatIndex { get; set; }
        public double? Luminosity { get; set; }
        public DateTime? InsertDate { get; set; }

    }
}
