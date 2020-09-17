using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGreenhouse.ViewModel
{
    public class LuminosityVM
    {
        public int Id { get; set; }
        public double? Luminosity { get; set; }
        public DateTime? InsertDate { get; set; }
    }
}
