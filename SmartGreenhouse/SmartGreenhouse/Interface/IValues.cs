using SmartGreenhouse.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGreenhouse.Interface
{
    public interface IValues
    {
        List<TemperatureVM> GetTemperatures();
        
        List<HumidityVM> GetHumidity();
        List<LuminosityVM> GetLuminosity();
        public void FanStatus();

        public void SaveData(double temperature, double humidity, double heat, double luminosity);

    }
}
