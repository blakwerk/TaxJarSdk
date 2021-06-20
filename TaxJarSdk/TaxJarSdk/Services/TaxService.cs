namespace TaxJarSdk.Implementation.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using TaxJarSdk.Core.Services;
    using TaxJarSdk.Models;
    using TaxJarSdk.Models.Extensions;
    using TaxJarSdk.Models.Requests;

    internal class TaxService : ITaxService
    {
        private readonly ILogger<TaxService> _logger;
        private readonly ITaxClient _taxClient;
        private readonly ITaxCalculator _taxCalculator;

        public TaxService(
            ILogger<TaxService> logger, 
            ITaxClient taxClient, 
            ITaxCalculator taxCalculator)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._taxClient = taxClient ?? throw new ArgumentNullException(nameof(taxClient));
            this._taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
        }

        /// <inheritdoc />
        public async Task<double> GetTaxRateForLocationAsync(ILocation location)
        {
            var taxRateRequest = location.ToTaxRateRequest();

            this._logger.LogInformation($"Looking up tax rates for zip: {taxRateRequest.ZipCode}");

            var response = await this._taxClient
                .GetTaxRateAsync(taxRateRequest)
                .ConfigureAwait(false);

            if (response.Error == null)
            {
                return response.Rate.CombinedDistrictRate;
            }

            this._logger.LogWarning(
                response.Error.Exception,
                "An error occurred fetching the response! ErrorCode: " +
                $"{response.Error.Code}. Error message: {response.Error.Message}");

            return double.NaN;
        }

        /// <inheritdoc />
        public async Task<double> CalculateTaxesAsync(IOrder order)
        {
            throw new NotImplementedException();
        }

    }
}
