using Microsoft.Extensions.Configuration;

namespace WebApiSeyyedi.Data
{
    public static class ConfigurationHelper
    {
        public static IConfiguration Config { get; set; }
        public static void InitConfig(IConfiguration configuration) => Config = configuration;
    }
}