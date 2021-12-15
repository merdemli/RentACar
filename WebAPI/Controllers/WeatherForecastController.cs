﻿using Core.CrossCuttingConcerns.Logging.Serilogger;
using Core.CrossCuttingConcerns.Logging.Serilogger.Abstract;
using Core.CrossCuttingConcerns.Logging.Serilogger.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly LoggerServiceBase _logger;

        //alternatif kullanım eklenecek
        public WeatherForecastController(FileLogger logger, Graylogger logger2) //LoggerServicebase logger;
        {
            _logger = logger;
            logger2.Debug("sdfsdf");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            _logger.Info("testLog");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
