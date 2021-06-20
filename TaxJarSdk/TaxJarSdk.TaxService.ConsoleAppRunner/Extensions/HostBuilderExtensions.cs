namespace TaxJarSdk.TaxService.ConsoleAppRunner.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using RestSharp;
    using TaxJarSdk.Core.Services;
    using TaxJarSdk.Implementation.Clients;
    using TaxJarSdk.Implementation.Services;

    /// <summary>
    /// Provides extension methods for <see cref="IHostBuilder"/>
    /// </summary>
    internal static class HostBuilderExtensions
    {
        /// <summary>
        /// Configures services for the app
        /// </summary>
        internal static IHostBuilder ConfigureServices(this IHostBuilder self)
        {
            return self.ConfigureServices((_, services) =>
            {
                services.AddHostedService<Worker>();

                services.AddTransient<ITaxService, TaxService>();
                services.AddTransient<ITaxCalculator, TaxCalculator>();
                services.AddTransient<ITaxClient, TaxClient>();
                services.AddTransient<IRestClient, RestClient>();
                services.AddTransient<TaxRateRunner>();
            });
        }
    }
}
