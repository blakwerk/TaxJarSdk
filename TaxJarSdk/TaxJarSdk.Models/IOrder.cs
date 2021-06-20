namespace TaxJarSdk.Models
{
    public interface IOrder
    {
        /// <summary>
        /// Gets or sets the unique id for this order.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or set the country code for the order. This property is required.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the shipping cost for the order. This property is required.
        /// </summary>
        public double ShippingCost { get; set; }

        /// <summary>
        /// Gets or sets the amount. TODO required for now.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// A flag indicating whether or not the order is ready for tax calculation.
        /// </summary>
        public bool IsOrderReadyForCalculation { get; }
    }
}