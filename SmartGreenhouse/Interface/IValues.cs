using SmartGreenhouse.ViewModel;
using System.Collections.Generic;

namespace SmartGreenhouse.Interface
{
    public interface IValues
    {
        List<TemperatureVM> GetTemperatures();
        
        List<HumidityVM> GetHumidity();
        List<LuminosityVM> GetLuminosity();
        List<GasVM> GetGas();


        public void SaveData(double temperature, double humidity, double heat, double luminosity);

    }
}
