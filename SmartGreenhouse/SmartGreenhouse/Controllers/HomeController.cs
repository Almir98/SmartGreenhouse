using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SmartGreenhouse.Database;
using SmartGreenhouse.Interface;
using SmartGreenhouse.ViewModel;

namespace SmartGreenhouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValues _service;
        private readonly SmartGreenHouseDb _database;
        private readonly IMapper _mapper;

        public HomeController(IValues service,IMapper mapper,SmartGreenHouseDb database)
        {
            _service = service;
            _mapper = mapper;
            _database = database;
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

        [HttpGet]
        public IActionResult AboutProject()
        {
            return View();
        }



        [HttpPost]
       
        public void TurnOnOff()
        {
            _service.FanStatus();
        }

        [HttpGet]
        public IActionResult ExportToExcel()
        {
            var list = _database.RecentValues.Select(e => new TemperatureVM { 
            
                Id=e.Id,
                Temperature=e.Temperature,
                HeatIndex=e.HeatIndex,
                InsertDate=e.InsertDate,
            }).ToList();

            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                for (int i = 0; i < list.Count(); i++)
                {
                    workSheet.Cells["D" + (i + 2).ToString()].Style.Numberformat.Format = "dd-mm-yyyy";
                }
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"TemperatureTable-{DateTime.Now.ToShortDateString()}.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }



    }
}
