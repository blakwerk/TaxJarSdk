namespace TaxJarSdk.TaxService.ConsoleAppRunner
{
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using TaxJarSdk.TaxService.ConsoleAppRunner.Extensions;

    /// <summary>
    /// Responsible for configuration and middleware.
    /// </summary>
    internal class Startup
    {
        public static IHostBuilder CreateHostBuilder()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console();

            Log.Logger = loggerConfiguration.CreateLogger();
            Log.Logger.Information("Application starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices();

            return host;
        }

        private static void BuildConfig(IConfigurationBuilder builder)
        {
            // add appsettings.json, then add env variables which
            // can override configs in appsettings.json
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
    }
}
