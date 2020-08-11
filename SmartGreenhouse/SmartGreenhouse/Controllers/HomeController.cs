using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartGreenhouse.Interface;
using SmartGreenhouse.Models;
using SmartGreenhouse.ViewModel;

namespace SmartGreenhouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValues _service;
        private readonly IMapper _mapper;


        public HomeController(IValues service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _service.GetTemperatures();
            return View(_mapper.Map<List<TemperatureVM>>(result));
        }

        [HttpGet]
        public IActionResult Humidity()
        {
            var result = _service.GetHumidity();
            return View(_mapper.Map<List<HumidityVM>>(result));
        }

        [HttpGet]
        public IActionResult Fan()
        {
            return View();
        }


    }
}
