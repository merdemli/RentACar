using Core.CrossCuttingConcerns.Logging.Serilog.Abstract;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core.Helpers;
using Serilog.Sinks.Graylog.Core.Transport;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Serilog
{
    public class Graylogger : LoggerServiceBase

    {
        public Graylogger()
        {
            var graylogOptions = new GraylogSinkOptions
            {
                Facility = "RentACar.WebAPI",
                HostnameOrAddress = "127.32.23.12:9000", //graylog adresi
                Port = 1212,
                UseSsl = false,
                Host = "",
                SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
                {
                    // 2020-AĞustos-03
                    DateFormatString = "yyyy-MM-dd"
                },
                TransportType = TransportType.Http,
                MinimumLogEventLevel = LogEventLevel.Verbose,
                MessageGeneratorType = MessageIdGeneratorType.Timestamp      //like id
            };
            var loggerConfig = new LoggerConfiguration(); //from serilog class
            loggerConfig.WriteTo.Graylog(graylogOptions);
            

            Logger = loggerConfig.CreateLogger(); //base'den gelen ILogger

        }
    }
}




