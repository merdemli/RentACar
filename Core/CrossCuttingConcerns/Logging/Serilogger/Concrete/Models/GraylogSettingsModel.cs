using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Serilogger.Concrete.Models
{
    public class GraylogSettingsModel
    {
        public string Facility { get; set; }
        public string HostnameOrAddress { get; set; }
        public int Port { get; set; }
        public string HostName { get; set; }
        public int TransportType { get; set; }
    }
}
