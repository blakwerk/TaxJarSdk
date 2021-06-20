namespace TaxJarSdk.Implementation.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using TaxJarSdk.Core.Services;
    using TaxJarSdk.Models;

    internal class TaxService : ITaxService
    {
        private readonly ILogger<TaxService> _logger;
        private readonly ITaxCalculator _taxClient;

        public TaxService(
            ILogger<TaxService> logger, 
            ITaxCalculator taxClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _taxClient = taxClient ?? throw new ArgumentNullException(nameof(taxClient));
        }

        /// <inheritdoc />
        public Task<double> GetTaxRateForLocationAsync(ILocation location)
        {
            _logger.LogInformation($"Looking up tax rates based on location zip: {location.ZipCode}");

            return _taxClient.GetTaxRateForLocationAsync(location);
        }

        /// <inheritdoc />
        public Task<double> GetTaxRateForLocationAsync(string zipCode)
        {
            _logger.LogInformation($"Looking up tax rates for zip: {zipCode}");

            return _taxClient.GetTaxRateForLocationAsync(zipCode);
        }

        /// <inheritdoc />
        public Task<double> CalculateTaxesAsync(IOrder order)
        {
            _logger.LogInformation($"Calculating taxes for order {order.Id}");

            return _taxClient.CalculateTaxesAsync(order);
        }
    }
}
