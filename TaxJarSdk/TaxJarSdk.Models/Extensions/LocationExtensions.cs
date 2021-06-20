namespace TaxJarSdk.Models.Extensions
{
    using TaxJarSdk.Models.Requests;

    public static class LocationExtensions
    {
        public static TaxRateRequest ToTaxRateRequest(this ILocation self)
        {
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