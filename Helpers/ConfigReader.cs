using Microsoft.Extensions.Configuration;
using System.IO;
using agros_repo.Models;

namespace agros_repo.Helpers
{
    public static class ConfigReader
    {
        public static IConfigurationRoot Configuration { get; }

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: true);

            Configuration = builder.Build();
        }

        public static string GetBaseUrl()
        {
            return Configuration["ApiSettings:BaseUrl"];
        }

        public static MenuPrices GetMenuPrices()
        {
            var prices = new MenuPrices();
            Configuration.GetSection("MenuPrices").Bind(prices);
            return prices;
        }
    }
}
