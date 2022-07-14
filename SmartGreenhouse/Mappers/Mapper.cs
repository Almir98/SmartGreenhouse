using AutoMapper;
using SmartGreenhouse.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGreenhouse.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<TemperatureVM,Database.RecentValues>().ReverseMap();
            CreateMap<HumidityVM, Database.RecentValues>().ReverseMap();
            CreateMap<LuminosityVM, Database.RecentValues>().ReverseMap();
            CreateMap<ValuesVM, Database.RecentValues>().ReverseMap();
            CreateMap<GasVM, Database.RecentValues>().ReverseMap();

        }
    }
}
