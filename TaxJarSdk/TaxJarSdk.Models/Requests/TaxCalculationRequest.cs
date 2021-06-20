namespace TaxJarSdk.Models.Requests
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a request to calculate the sales tax which should be collected for an order.
    /// </summary>
    public class TaxCalculationRequest
    {
        /// <summary>
        /// Gets or sets the Id for a given order. 
        /// </summary>
        [JsonIgnore]
        public string Id { get; set; }

        /// <summary>
        /// Two-letter ISO country code of the country where the order shipped from. 
        /// </summary>
        [JsonProperty("from_country")]
        public string FromCountry { get; set; }

        /// <summary>
        /// Postal code where the order shipped from (5-Digit ZIP or ZIP+4).
        /// </summary>
        [JsonProperty("from_zip")]
        public string FromZip { get; set; }

        /// <summary>
        /// Two-letter ISO state code where the order shipped from.
        /// </summary>
        [JsonProperty("from_state")]
        public string FromState { get; set; }

        /// <summary>
        /// City where the order shipped from.
        /// </summary>
        [JsonProperty("from_city")]
        public string FromCity { get; set; }

        /// <summary>
        /// Street address where the order shipped from.
        /// </summary>
        [JsonProperty("from_street")]
        public string FromStreet { get; set; }

        /// <summary>
        /// Two-letter ISO country code of the country where the order shipped to.
        /// </summary>
        [JsonProperty("to_country")]
        public string ToCountry { get; set; }

        /// <summary>
        /// Postal code where the order shipped to (5-Digit ZIP or ZIP+4).
        /// </summary>
        [JsonProperty("to_zip")]
        public string ToZip { get; set; }

        /// <summary>
        /// Two-letter ISO state code where the order shipped to.
        /// </summary>
        [JsonProperty("to_state")]
        public string ToState { get; set; }

        /// <summary>
        /// City where the order shipped to.
        /// </summary>
        [JsonProperty("to_city")]
        public string ToCity { get; set; }

        /// <summary>
        /// Street address where the order shipped to.
        /// </summary>
        [JsonProperty("to_street")]
        public string ToStreet { get; set; }

        /// <summary>
        /// Total amount of the order, excluding shipping.
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Total amount of shipping for the order.
        /// </summary>
        [JsonProperty("shipping")]
        public double Shipping { get; set; }

        /// <summary>
        /// Unique identifier of the given customer for exemptions.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Type of exemption for the order: wholesale, government, marketplace, other, or non_exempt.
        /// </summary>
        [JsonProperty("exemption_type")]
        public string ExemptionType { get; set; }

        /// <summary>
        /// Gets or sets the collection of nexus addresses (addresses on file). Either
        /// this property or the From[X] properties are required to perform tax
        /// calculations.
        /// </summary>
        [JsonProperty("nexus_addresses")]
        public IEnumerable<NexusAddress> NexusAddresses { get; set; }

        /// <summary>
        /// Gets or sets the line items. Either Amount or LineItems properties are
        /// required to perform tax calculations.
        /// </summary>
        [JsonProperty("line_items")]
        public IEnumerable<LineItem> LineItems { get;set; }
    }
}
