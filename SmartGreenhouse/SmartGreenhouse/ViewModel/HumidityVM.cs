using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGreenhouse.ViewModel
{
    public class HumidityVM
    {
        public int Id { get; set; }
        public double? Humidity { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
