using Serilog;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core.Transport;
using Microsoft.Extensions.Configuration;
using Core.CrossCuttingConcerns.Logging.Serilogger.Abstract;
using Core.CrossCuttingConcerns.Logging.Serilogger.Concrete.Models;

namespace Core.CrossCuttingConcerns.Logging.Serilogger
{
   
    public class Graylogger : LoggerServiceBase
    {
        public Graylogger(IConfiguration configuration)
        {
            var jsonOpts = configuration.GetSection("SerilogSettings:GraylogSettings:Facility").Get<GraylogSettingsModel>();
            var options = new GraylogSinkOptions
            {
                Facility = jsonOpts.Facility,
                HostnameOrAddress = jsonOpts.HostnameOrAddress,
                Port = (int)jsonOpts.Port,
                UseSsl = false,
                Host = jsonOpts.HostName,
                TransportType = (TransportType)jsonOpts.TransportType

                //Enum.Parse(TransportType, options.TransportType)//string için "1"
            };
            Logger = new LoggerConfiguration().WriteTo.Graylog(options).CreateLogger();


            //var graylogOptions = new GraylogSinkOptions
            //{
            //    Facility = "RentACar.WebAPI",
            //    HostnameOrAddress = "127.32.23.12:9000", //graylog adresi
            //    Port = 1212,
            //    UseSsl = false,
            //    Host = "",
            //    SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings
            //    {
            //         2020-AĞustos-03
            //        DateFormatString = "yyyy-MM-dd"
            //    },
            //    TransportType = TransportType.Http,
            //    MinimumLogEventLevel = LogEventLevel.Verbose,
            //    MessageGeneratorType = MessageIdGeneratorType.Timestamp //like id
            //};
            //var loggerConfig = new LoggerConfiguration(); //from serilog class
            //loggerConfig.WriteTo.Graylog(graylogOptions);

            //Logger = loggerConfig.CreateLogger(); //base'den gelen ILogger

        }
    }
}




