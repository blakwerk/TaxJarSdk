namespace TaxJarSdk.Tests.Fakes
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using RestSharp;
    using TaxJarSdk.Implementation.Clients;
    using TaxJarSdk.Models.Responses;

    /// <summary>
    /// Default pass-through wrapper for protected BaseClient.
    /// </summary>
    internal sealed class TestableBaseClientWrapper : BaseClient
    {
        /// <inheritdoc />
        public TestableBaseClientWrapper(
            ILogger<BaseClient> logger, 
            IRestClient client, 
            IConfiguration config) : base(logger, client, config)
        {
        }

        public new Task<TResponse> GetAsync<TResponse>(string path) where TResponse : IResponse, new()
        {
            return base.GetAsync<TResponse>(path);
        }

        public new Task<TResponse> PostAsync<TRequest, TResponse>(string path, TRequest request)
            where TResponse : IResponse, new()
        {
            return base.PostAsync<TRequest, TResponse>(path, request);
        }
    }
}