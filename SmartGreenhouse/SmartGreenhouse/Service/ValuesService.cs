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
        private readonly SmartGreenHouseDbContext _context;
        private readonly IMapper _mapper;

        public ValuesService(SmartGreenHouseDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
