namespace TaxJarSdk.TaxService.ConsoleAppRunner
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

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

            await this._taxRateRunner.RequestTaxCalculationForSantaMonicaOrderAsync();
        }

        /// <inheritdoc />
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            this._logger.LogInformation("Worker shutting down.");
        }
    }
}