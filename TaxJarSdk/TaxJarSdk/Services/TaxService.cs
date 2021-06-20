namespace TaxJarSdk.Implementation.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using TaxJarSdk.Core.Clients;
    using TaxJarSdk.Core.Services;
    using TaxJarSdk.Models;
    using TaxJarSdk.Models.Extensions;
    using TaxJarSdk.Models.Responses;

    internal class TaxService : ITaxService
    {
        private readonly ILogger<TaxService> _logger;
        private readonly ITaxClient _taxClient;

        public TaxService(
            ILogger<TaxService> logger, 
            ITaxClient taxClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _taxClient = taxClient ?? throw new ArgumentNullException(nameof(taxClient));
        }

        /// <inheritdoc />
        public async Task<double> GetTaxRateForLocationAsync(ILocation location)
        {
            _logger.LogInformation($"Looking up tax rates based on location zip: {location.ZipCode}");

            var response = await _taxClient
                .GetTaxRateAsync(location.ToTaxRateRequest())
                .ConfigureAwait(false);

            return this.HandleRaxRateResponse(response);
        }

        /// <inheritdoc />
        public async Task<double> GetTaxRateForLocationAsync(string zipCode)
        {
            _logger.LogInformation($"Looking up tax rates for zip: {zipCode}");

            var response = await _taxClient
                .GetTaxRateAsync(zipCode)
                .ConfigureAwait(false);

            return this.HandleRaxRateResponse(response);
        }

        /// <inheritdoc />
        public async Task<double> CalculateTaxesAsync(IOrder order)
        {
            _logger.LogInformation($"Calculating taxes for order {order.Id}");

            var response = await _taxClient
                .CalculateSalesTaxAsync(order.ToCalculationRequest())
                .ConfigureAwait(false);

            if (response.Error == null)
            {
                return response.Taxes.TaxAmountToCollect;
            }

            _logger.LogWarning(
                response.Error.Exception,
                "An error occurred fetching the response! ErrorCode: " +
                $"{response.Error.Code}. Error message: {response.Error.Message}");

            return double.NaN;
        }

        private double HandleRaxRateResponse(TaxRateResponse response)
        {
            if (response.Error == null)
            {
                return response.Rate.CombinedDistrictRate;
            }

            _logger.LogWarning(
                response.Error.Exception,
                "An error occurred fetching the response! ErrorCode: " +
                $"{response.Error.Code}. Error message: {response.Error.Message}");

            return double.NaN;
        }
    }
}
