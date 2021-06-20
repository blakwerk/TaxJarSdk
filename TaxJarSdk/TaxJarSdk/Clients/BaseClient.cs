namespace TaxJarSdk.Implementation.Clients
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using RestSharp;
    using TaxJarSdk.Implementation.Extensions;
    using TaxJarSdk.Models;
    using TaxJarSdk.Models.Extensions;
    using TaxJarSdk.Models.Requests;
    using TaxJarSdk.Models.Responses;

    internal class BaseClient
    {
        private readonly IConfiguration _config;

        protected readonly IRestClient Client;
        protected readonly ILogger<BaseClient> Logger;

        protected BaseClient(
            ILogger<BaseClient> logger,
            IRestClient client,
            IConfiguration config)
        {
            this.Client = client ?? throw new ArgumentNullException(nameof(client));
            this._config = config ?? throw new ArgumentNullException(nameof(config));
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            this.Client.BaseUrl = new Uri("https://api.sandbox.taxjar.com/v2/");

            // Add default headers
            this.Client.AddDefaultHeader("Content-Type", "application/json");
            this.Client.AddDefaultHeader("Authorization", $"Bearer {config.GetTaxJarApiKey()}");
        }

        protected async Task<TResponse> GetAsync<TResponse>(string path) where TResponse : IResponse, new()
        {
            var request = new RestRequest(path, DataFormat.Json);
            
            try
            {
                var apiResponse = await this.Client
                    .ExecuteGetAsync<TResponse>(request)
                    .ConfigureAwait(false);

                if (apiResponse.IsSuccessful)
                {
                    return apiResponse.Data;
                }

                this.Logger.LogWarning($"Request to \"{path}\" not OK. Status returned was {apiResponse.StatusCode}");
                return apiResponse.StatusCode.ToErrorResponse<TResponse>();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, $"Request to \"{path}\" failed");

                var error = Errors.InternalServerError($"Request to \"{path}\" threw exception {ex.Message}");
                error.Exception = ex;

                return new TResponse
                {
                    Error = error,
                };
            }
        }

        protected async Task<TResponse> PostAsync<TRequest, TResponse>(string path, TRequest request)
            where TResponse : IResponse, new()
        {
            var jsonBody = JsonConvert.SerializeObject(request);
            var restRequest = new RestRequest(path, Method.POST).AddJsonBody(jsonBody);
            restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            try
            {
                var apiResponse = await this.Client
                    .ExecuteAsync(restRequest)
                    .ConfigureAwait(false);

                if (apiResponse.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<TResponse>(apiResponse.Content);
                }

                this.Logger.LogWarning($"Request to \"{path}\" not OK. Status returned was {apiResponse.StatusCode}");
                return apiResponse.StatusCode.ToErrorResponse<TResponse>();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, $"Request to \"{path}\" failed");

                var error = Errors.InternalServerError($"Request to \"{path}\" threw exception {ex.Message}");
                error.Exception = ex;

                return new TResponse
                {
                    Error = error,
                };
            }
        }
    }
}
