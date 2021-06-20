namespace TaxJarSdk.Models
{
    using System.Collections.Generic;
    using TaxJarSdk.Models.Requests;

    /// <summary>
    /// Represents an order.
    /// </summary>
    public class Order : IOrder
    {
        /// <inheritdoc />
        public string Id { get; set; }

        /// <inheritdoc />
        public ILocation FromLocation { get; set; }

        /// <inheritdoc />
        public ILocation ToLocation { get; set; }

        /// <inheritdoc />
        public double Amount { get; set; }

        /// <inheritdoc />
        public double Shipping { get; set; }

        /// <inheritdoc />
        public string CustomerId { get; set; }

        /// <inheritdoc />
        public Exemption Exemption { get; set; }

        /// <inheritdoc />
        public IEnumerable<IKnownLocation> KnownLocations { get; set; }

        /// <inheritdoc />
        public IEnumerable<LineItem> LineItems { get; set; }
    }
}