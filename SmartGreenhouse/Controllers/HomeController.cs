using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SmartGreenhouse.Database;
using SmartGreenhouse.Interface;
using SmartGreenhouse.ViewModel;

namespace SmartGreenhouse.Controllers
{
    [EnableCors("AllowAll")]
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
        public IActionResult Gas()
        {
            var result = _service.GetGas();
            var lastGas = _service.GetGas().Last().Gas;
            ViewBag.last = lastGas;
            return View(_mapper.Map<List<GasVM>>(result));
        }


        [EnableCors("AllowAll")]
        public IActionResult Save(int temperature, int humidity, int heat, int luminosity, int gas)
        {
            RecentValues entity = new RecentValues();
            
            entity.Temperature = temperature;
            entity.Humidity = humidity;
            entity.HeatIndex = heat;
            entity.Luminosity = luminosity;
            entity.Gas = gas;
            entity.InsertDate = DateTime.Now.Date;

            _database.Add(entity);
            _database.SaveChanges();

            var result = _service.GetTemperatures().Last().Temperature;
            ViewBag.last = result;

            return Json(entity);
        }

        [HttpGet]
        public IActionResult AboutProject()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExportTemperatureToExcel()
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
            string excelName = $"Temperature-data-{DateTime.Now.ToShortDateString()}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }

        [HttpGet]
        public IActionResult ExportHumidityToExcel()
        {
            var list = _database.RecentValues.Select(e => new HumidityVM
            {

                Id = e.Id,
                Humidity = e.Humidity,
                InsertDate = e.InsertDate,
            }).ToList();
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                for (int i = 0; i < list.Count(); i++)
                {
                    workSheet.Cells["C" + (i + 2).ToString()].Style.Numberformat.Format = "dd-mm-yyyy";
                }
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"Humidity-data-{DateTime.Now.ToShortDateString()}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
        
        [HttpGet]
        public IActionResult ExportLuminosityToExcel()
        {
            var list = _database.RecentValues.Select(e => new LuminosityVM
            {

                Id = e.Id,
                Luminosity = e.Luminosity,
                InsertDate = e.InsertDate,
            }).ToList();
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                for (int i = 0; i < list.Count(); i++)
                {
                    workSheet.Cells["C" + (i + 2).ToString()].Style.Numberformat.Format = "dd-mm-yyyy";
                }
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"Luminosity-data-{DateTime.Now.ToShortDateString()}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }

        [HttpGet]
        public IActionResult ExportGasToExcel()
        {
            var list = _database.RecentValues.Select(e => new GasVM
            {

                Id = e.Id,
                Gas = e.Gas,
                InsertDate = e.InsertDate,
            }).ToList();
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                for (int i = 0; i < list.Count(); i++)
                {
                    workSheet.Cells["C" + (i + 2).ToString()].Style.Numberformat.Format = "dd-mm-yyyy";
                }
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"Gas-data-{DateTime.Now.ToShortDateString()}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
