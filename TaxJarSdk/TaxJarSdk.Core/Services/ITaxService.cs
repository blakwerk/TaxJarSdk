namespace TaxJarSdk.Core.Services
{
    using System.Threading.Tasks;
    using TaxJarSdk.Models;

    public interface ITaxService
    {
        // Get tax rates for a location
        Task<double> GetTaxRateForLocationAsync(ILocation location);

        /// <summary>
        /// Uses a <see cref="ITaxCalculator"/> to calculate the taxes for the <see cref="IOrder"/>
        /// </summary>
        Task<double> CalculateTaxesAsync(IOrder order);
    }

    public interface ITaxCalculator
    {

    }
}
