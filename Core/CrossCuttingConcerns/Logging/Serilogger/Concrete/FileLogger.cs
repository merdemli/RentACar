using Core.CrossCuttingConcerns.Logging.Serilogger.Abstract;
using Serilog;
using System.IO;

namespace Core.CrossCuttingConcerns.Logging.Serilogger.Concrete
{

    public class FileLogger : LoggerServiceBase
    {
        public FileLogger()
        {
            var logPath = Directory.GetCurrentDirectory() + @"\log.txt";

            //Log.Logger = new LoggerConfiguration()
            var loggerConfig = new LoggerConfiguration(); //from serilog class
            loggerConfig.WriteTo.File(logPath, rollingInterval: RollingInterval.Day);
            Logger = loggerConfig.CreateLogger();
        }
    }
}
    