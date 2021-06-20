namespace TaxJarSdk.Models.Extensions
{
    using System.Runtime.InteropServices;
    using TaxJarSdk.Models.Requests;

    public static class LocationExtensions
    {
        /// <summary>
        /// Constructs a <see cref="TaxRateRequest"/>
        /// </summary>
        public static TaxRateRequest ToTaxRateRequest(this ILocation self)
        {
            if (self == null)
            {
                return null;
            }

            return new TaxRateRequest
            {
                City = self.City,
                Country = self.Country,
                State = self.State,
                Street = self.Street,
                ZipCode = self.ZipCode,
            };
        }
    }
}