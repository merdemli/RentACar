using Core.CrossCuttingConcerns.Logging.Serilogger.Concrete.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static GraylogSettingsModel GetSomething(this IServiceCollection services, IConfiguration configuration)
        {
            var model = configuration.GetSection("SerilogSettings:GraylogSettings:Facility").Get<GraylogSettingsModel>();
            return model;
        }
    }
}