using AutoMapper;
using SmartGreenhouse.Database;
using SmartGreenhouse.Interface;
using SmartGreenhouse.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGreenhouse.Service
{
    public class ValuesService:IValues
    {
        private readonly SmartGreenHouseDb _context;
        private readonly IMapper _mapper;

        public ValuesService(SmartGreenHouseDb context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void FanStatus()
        {
            var result = _context.RecentValues.Last();
            if (result.FanStatus == true)
            {
                result.FanStatus = false;
            }
            else
            {
                result.FanStatus = true;
            }
        }

        public List<HumidityVM> GetHumidity()
        {
            var result = _context.RecentValues.ToList();
            return _mapper.Map<List<HumidityVM>>(result);
        }

        public List<LuminosityVM> GetLuminosity()
        {
            var result = _context.RecentValues.ToList();
            return _mapper.Map<List<LuminosityVM>>(result);
        }

        public List<TemperatureVM> GetTemperatures()
        {
            var result = _context.RecentValues.ToList();
            return _mapper.Map<List<TemperatureVM>>(result);
        }



    }
}
