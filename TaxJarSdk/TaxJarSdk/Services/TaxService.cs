namespace TaxJarSdk.Implementation.Services
{
    using System;
    using System.Threading.Tasks;
    using TaxJarSdk.Core.Services;

    internal class TaxService : ITaxService
    {
        /// <inheritdoc />
        public async Task<double> CalculateTaxesAsync(IOrder order)
        {
            throw new NotImplementedException();
        }
    }

    internal class ServiceError : IServiceError
    {
        public string Code { get; set; }

        public string Message { get; set; }
        
        public Exception Exception { get; set; }
    }
}
