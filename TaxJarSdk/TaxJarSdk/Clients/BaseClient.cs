namespace TaxJarSdk.Implementation.Clients
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using RestSharp;
    using TaxJarSdk.Core.Services;
    using TaxJarSdk.Implementation.Services;

    internal class BaseClient
    {
        protected readonly IRestClient Client;
        private readonly IConfiguration _config;
        protected readonly ILogger<BaseClient> Logger;

        protected BaseClient(
            ILogger<BaseClient> logger,
            IRestClient client,
            IConfiguration config)
        {
            this.Client = client ?? throw new ArgumentNullException(nameof(client));
            this._config = config ?? throw new ArgumentNullException(nameof(config));
            this.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            this.Client.BaseUrl = new Uri("https://api.taxjar.com/v2/");

            // Add default headers
            // TODO: get bearer token from config
            this.Client.AddDefaultHeader("Content-Type", "application/json");
            this.Client.AddDefaultHeader("Authorization:", "Bearer 9e0cd62a22f451701f29c3bde214");
        }

        protected Task<TResponse> GetAsync<TResponse>(string path) where TResponse : IResponse, new()
        {
            var request = new RestRequest(path, DataFormat.Json);

            try
            {
                //var foo = this.Client.Get<TResponse>(request);
                //this.Client.GetA
                //var response = this.Client.ExecuteGetAsync<TResponse>(request);
                var response = this.Client.GetAsync<TResponse>(request);

                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, $"Request to \"{path}\" failed");
                var defaultResponse = default(TResponse);
                
                if(defaultResponse != null)
                {
                    defaultResponse.ServiceError = new ServiceError
                    {
                        Exception = ex,
                        Message = ex.GetBaseException().Message,
                        Code = "",
                    };
                }

                return Task.FromResult(defaultResponse);
            }
        }

        //private async Task<TResponse> SendRequestAsync<TResponse>(IRestRequest request)
        //{
        //    var response = default(IRestResponse<TResponse>);
        //    var exception = default(Exception);

        //    try
        //    {
        //        response = await this.Client.ExecuteAsync<TResponse>(request).ConfigureAwait(false);
                

        //        switch (response.StatusCode)
        //        {
        //            case HttpStatusCode.OK:
        //                response = new TResponse();
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        exception = ex;

        //        this.Logger.LogError(ex, $"Error getting response.");
        //    }
        //}

        //private static bool IsJson(HttpResponseMessage message)
        //{
            
        //}
    }

    internal class TaxCalculatorClient : BaseClient
    {
        internal TaxCalculatorClient(
            ILogger<TaxCalculatorClient> logger,
            IRestClient client,
            IConfiguration config) : base(logger, client, config)
        {
        }


    }
}
