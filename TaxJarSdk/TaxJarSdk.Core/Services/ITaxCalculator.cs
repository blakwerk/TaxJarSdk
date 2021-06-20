namespace TaxJarSdk.Core.Services
{
    using System.Threading.Tasks;
    using TaxJarSdk.Models;

    /// <summary>
    /// Specification for a tax calculator
    /// </summary>
    public interface ITaxCalculator
    {
        /// <summary>
        /// Get tax rates for a location based on <see cref="ILocation"/> information.
        /// </summary>
        Task<double> GetTaxRateForLocationAsync(ILocation location);

        /// <summary>
        /// Get tax rates for a location based on zip code.
        /// </summary>
        Task<double> GetTaxRateForLocationAsync(string zipCode);

        /// <summary>
        /// Gets the sales tax that should be collected for a given <see cref="IOrder"/>
        /// </summary>
        Task<double> CalculateTaxesAsync(IOrder order);
    }
}
