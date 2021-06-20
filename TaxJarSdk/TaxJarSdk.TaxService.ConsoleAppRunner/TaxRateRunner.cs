namespace TaxJarSdk.TaxService.ConsoleAppRunner
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using TaxJarSdk.Core.Services;
    using TaxJarSdk.Models;

    /// <summary>
    /// A live test class with which to get real data.
    /// </summary>
    public class TaxRateRunner
    {
        private readonly ILocation _santaMonica = new Location
        {
            City = "Santa Monica",
            State = "CA",
            ZipCode = "90404",
        };

        private readonly Order _laJollaToLosAngelesOrder = new()
        {
            FromLocation = new Location
            {
                Country = "US",
                City = "La Jolla",
                State = "CA",
                ZipCode = "92093",
                Street = "9500 Gilman Drive"
            },
            ToLocation = new Location
            {
                Country = "US",
                City = "Los Angeles",
                State = "CA",
                ZipCode = "90002",
                Street = "1335 E 103rd St"
            },
            Amount = 15,
            Shipping = 1.5,
            LineItems = new []
            {
                new LineItem
                {
                    Discount = 0,
                    Id = "12345",
                    ProductTaxCode = "20010",
                    Quantity = 1,
                    UnitPrice = 15,
                },
            },
            KnownLocations = new []
            {
                new NexusAddress
                {
                    Id = "main location",
                    Country = "US",
                    ZipCode = "92093",
                    State = "CA",
                    City = "La Jolla",
                    Street = "9500 Gilman Drive",
                },
            },
        };

        private readonly ILogger<TaxRateRunner> _logger;
        private readonly ITaxService _taxService;

        public TaxRateRunner(
            ILogger<TaxRateRunner> logger,
            ITaxService taxService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            if (taxService != null) _taxService = taxService;
        }

        /// <summary>
        /// Tests getting the tax rate for santa monica
        /// </summary>
        public async Task RequestSantaMonicaTaxRatesAsync()
        {
            _logger.LogInformation("Requesting tax information for santa monica: ");

            var rate = await _taxService
                .GetTaxRateForLocationAsync(_santaMonica)
                .ConfigureAwait(false);

            _logger.LogInformation($"Tax rate for Santa Monica: {rate}");
        }

        /// <summary>
        /// Tests getting the tax rate for santa monica
        /// </summary>
        public async Task RequestTaxCalculationForSantaMonicaOrderAsync()
        {
            _logger.LogInformation("Requesting tax calculation " +
                                        "for order from santa monica to new york: ");

            var rate = await _taxService
                .CalculateTaxesAsync(_laJollaToLosAngelesOrder)
                .ConfigureAwait(false);

            _logger.LogInformation($"Tax calculation for order: {rate}");
        }
    }
}