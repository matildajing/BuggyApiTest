using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BuggyApiTest.Drivers
{
    public class ConfigurationDriver
    {

        private const string KeyBaseUrl = "BaseUrl";
        private const string KeyRegisterPath = "RegisterPath";

        private readonly Lazy<IConfiguration> _configurationLazy;

        public ConfigurationDriver() => _configurationLazy = new Lazy<IConfiguration>(GetConfiguration);

        public IConfiguration Configuration => _configurationLazy.Value;

        public string BaseUrl => Configuration[KeyBaseUrl];
        public string RegisterPath => Configuration[KeyRegisterPath];

        private IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();

            string directoryName = Path.GetDirectoryName(typeof(ConfigurationDriver).Assembly.Location);
            configurationBuilder.AddJsonFile(Path.Combine(directoryName, @"settings.json"));

            return configurationBuilder.Build();
        }
    }
}
