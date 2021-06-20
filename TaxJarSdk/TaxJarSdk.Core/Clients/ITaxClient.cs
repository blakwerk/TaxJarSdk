namespace TaxJarSdk.Core.Clients
{
    using System.Threading.Tasks;
    using TaxJarSdk.Models.Requests;
    using TaxJarSdk.Models.Responses;

    /// <summary>
    /// Represents a tax client.
    /// </summary>
    public interface ITaxClient
    {
        /// <summary>
        /// Gets the tax rate.
        /// </summary>
        Task<TaxRateResponse> GetTaxRateAsync(TaxRateRequest request);

        /// <summary>
        /// Gets the tax rate.
        /// </summary>
        Task<TaxRateResponse> GetTaxRateAsync(string zipCode);

        /// <summary>
        /// Gets the sales tax to be collected.
        /// </summary>
        Task<TaxCalculationResponse> CalculateSalesTaxAsync(TaxCalculationRequest request);
    }
}