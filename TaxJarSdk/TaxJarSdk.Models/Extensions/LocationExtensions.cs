namespace TaxJarSdk.Models.Extensions
{
    using System.Linq;
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

    public static class OrderExtensions
    {
        /// <summary>
        /// Constructs a <see cref="TaxCalculationRequest"/>
        /// </summary>
        public static TaxCalculationRequest ToCalculationRequest(this IOrder self)
        {
            if (self == null)
            {
                return null;
            }

            return new TaxCalculationRequest
            {
                Amount = self.Amount,
                CustomerId = self.CustomerId,
                ExemptionType = self.Exemption.ToApiString(),
                FromCity = self.FromLocation?.City,
                FromCountry = self.FromLocation?.Country,
                FromState = self.FromLocation?.State,
                FromStreet = self.FromLocation?.Street,
                FromZip = self.FromLocation?.ZipCode,
                Id = self.Id,
                LineItems = self.LineItems,
                NexusAddresses = self.KnownLocations.Select(kl =>
                    new NexusAddress
                    {
                        City = kl.City,
                        Country = kl.Country,
                        Id = kl.Id,
                        State = kl.State,
                        Street = kl.Street,
                        ZipCode = kl.ZipCode,
                    }),
                Shipping = self.Shipping,
                ToCity = self.ToLocation?.City,
                ToCountry = self.ToLocation?.Country,
                ToState = self.ToLocation?.State,
                ToStreet = self.ToLocation?.Street,
                ToZip = self.ToLocation?.ZipCode,
            };
        }
    }
}