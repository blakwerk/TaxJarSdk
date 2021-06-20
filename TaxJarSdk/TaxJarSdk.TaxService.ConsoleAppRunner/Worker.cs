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
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _taxRateRunner = taxRateRunner;
        }

        /// <inheritdoc />
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker starting up.");

            await _taxRateRunner.RequestSantaMonicaTaxRatesAsync();

            await _taxRateRunner.RequestTaxCalculationForSantaMonicaOrderAsync();
        }

        /// <inheritdoc />
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker shutting down.");
        }
    }
}