using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartGreenhouse.Interface;
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

            var lastTemperature = result.Last().Temperature;
            ViewBag.last = lastTemperature;
            return View(_mapper.Map<List<TemperatureVM>>(result));
        }

        [HttpGet]
        public IActionResult Humidity()
        {
            var result = _service.GetHumidity();
            var lastHumidity = _service.GetHumidity().Last().Humidity;
            ViewBag.last = lastHumidity;
            return View(_mapper.Map<List<HumidityVM>>(result));
        }

        [HttpGet]
        public IActionResult Luminosity()
        {
            var result = _service.GetLuminosity();
            var lastLuminosity = _service.GetLuminosity().Last().Luminosity;
            ViewBag.last = lastLuminosity;
            return View(_mapper.Map<List<LuminosityVM>>(result));
        }

        [HttpGet]
        public IActionResult Fan()
        {
            return View();
        }


        [HttpPost]
       
        public void TurnOnOff()
        {
            _service.FanStatus();
        }

    }
}
