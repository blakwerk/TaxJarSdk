namespace TaxJarSdk.Implementation.Clients
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using RestSharp;
    using TaxJarSdk.Core.Clients;
    using TaxJarSdk.Implementation.Extensions;
    using TaxJarSdk.Models.Requests;
    using TaxJarSdk.Models.Responses;

    internal sealed class TaxClient : BaseClient, ITaxClient
    {
        public TaxClient(
            ILogger<TaxClient> logger,
            IRestClient client,
            IConfiguration config) : base(logger, client, config)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (config == null) throw new ArgumentNullException(nameof(config));

            // configure base url
            base.Client.BaseUrl = new Uri("https://api.sandbox.taxjar.com/v2/");

            // Add default headers
            base.Client.AddDefaultHeader("Content-Type", "application/json");
            base.Client.AddDefaultHeader("Authorization", $"Bearer {config.GetTaxJarApiKey()}");
        }

        /// <inheritdoc />
        public Task<TaxRateResponse> GetTaxRateAsync(string zipCode)
        {
            return this.GetAsync<TaxRateResponse>($"rates/{zipCode}");
        }

        /// <inheritdoc />
        public Task<TaxRateResponse> GetTaxRateAsync(TaxRateRequest request)
        {
            return this.PostAsync<TaxRateRequest, TaxRateResponse>("rates/", request);
        }

        /// <inheritdoc />
        public Task<TaxCalculationResponse> CalculateSalesTaxAsync(TaxCalculationRequest request)
        {
            return this.PostAsync<TaxCalculationRequest, TaxCalculationResponse>("taxes/", request);
        }
    }
}