using AP.IdentityServer.Configurations.Statics;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AP.IdentityServer.Configurations
{
    public static class ConfigurationStatic
    {
        public static IConfiguration GetConfiguration(string? env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();


            // var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            try
            {
                // src/Apis/DVG.AP.Cms.NewCar.Api/Configurations/FileSettings/Testing/StorageSetting.json
                // Environment variable SITE_NAME set when build Docker images
                WebsiteManager.SiteName = Environment.GetEnvironmentVariable("SITE_NAME") ?? WebsiteManager.DefaultSiteName; //  Site name for get Configuration Files in Configurations/FileSettings 
                Console.WriteLine($"{DateTime.Now}: You're working on {WebsiteManager.SiteName}");
                var pathConfig = $"Configurations/AppSettings/{WebsiteManager.SiteName}";

                var pathFileConfig = $"{pathConfig}/{env}/";
                foreach (var jsonFilename in Directory.EnumerateFiles(pathFileConfig, "*.json", SearchOption.AllDirectories))
                    builder.AddJsonFile(jsonFilename);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception($"Configuration file in environment: {env}");
            }
            return builder.Build();
        }
    }
}
