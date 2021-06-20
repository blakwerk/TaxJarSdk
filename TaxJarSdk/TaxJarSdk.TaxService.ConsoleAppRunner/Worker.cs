namespace TaxJarSdk.TaxService.ConsoleAppRunner
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using TaxJarSdk.Core.Services;
    using TaxJarSdk.Models.Requests;

    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> _logger;
        private readonly TaxRateRunner _taxRateRunner;

        public Worker(
            ILogger<Worker> logger,
            TaxRateRunner taxRateRunner)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._taxRateRunner = taxRateRunner;
        }

        /// <inheritdoc />
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Worker starting up.");

            await this._taxRateRunner.RequestSantaMonicaTaxRatesAsync();
        }

        /// <inheritdoc />
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Worker shutting down.");
        }
    }

    /// <summary>
    /// A live test class with which to get real data.
    /// </summary>
    public class TaxRateRunner
    {
        private readonly TaxRateRequest _santaMonicaRateRequest = new()
        {
            City = "Santa Monica",
            State = "CA",
            ZipCode = "90404",
        };

        private readonly ILogger<TaxRateRunner> _logger;
        private readonly ITaxService _taxService;

        public TaxRateRunner(
            ILogger<TaxRateRunner> logger,
            ITaxService taxService)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            if (taxService != null) this._taxService = taxService;
        }

        /// <summary>
        /// Tests getting the tax rate for santa monica
        /// </summary>
        public async Task RequestSantaMonicaTaxRatesAsync()
        {
            this._logger.LogInformation("Requesting tax information for santa monica: ");

            var rate = await this._taxService.GetTaxRateForLocationAsync(this._santaMonicaRateRequest);

            this._logger.LogInformation($"Tax rate for Santa Monica: {rate}");
        }
    }
}