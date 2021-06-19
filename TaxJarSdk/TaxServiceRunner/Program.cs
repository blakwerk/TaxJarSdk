namespace TaxServiceRunner
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Serilog;
    using TaxJarSdk.Core.Services;
    using TaxJarSdk.Implementation.Services;

    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var host = CreateHostBuilder();
            await host.RunConsoleAsync();
            return Environment.ExitCode;
        }

        private static IHostBuilder CreateHostBuilder()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application starting");

            var host = Host.CreateDefaultBuilder()
                .UseSerilog((context, configuration) =>
                {
                    configuration.ReadFrom.Configuration(context.Configuration);
                })
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();

                    services.AddTransient<ITaxService, TaxService>();
                });

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

    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> logger;

        public Worker(ILogger<Worker> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Worker starting up.");
        }

        /// <inheritdoc />
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            this.logger.LogInformation("Worker shutting down.");
        }
    }
}
