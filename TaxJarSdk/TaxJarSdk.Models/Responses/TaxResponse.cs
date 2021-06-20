namespace TaxJarSdk.Models.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents raw tax information about a given order. 
    /// </summary>
    public class TaxResponse
    {
        /// <summary>
        /// Gets or sets the total order amount.
        /// </summary>
        [JsonProperty("order_total_amount")]
        public double TotalOrderAmount { get; set; }

        /// <summary>
        /// Total amount of shipping for the order.
        /// </summary>
        [JsonProperty("shipping")]
        public double Shipping { get; set; }

        /// <summary>
        /// Amount of the order to be taxed.
        /// </summary>
        [JsonProperty("taxable_amount")]
        public double TaxableAmount { get; set; }

        /// <summary>
        /// Amount of sales tax to collect.
        /// </summary>
        [JsonProperty("amount_to_collect")]
        public double TaxAmountToCollect { get; set; }

        /// <summary>
        /// Overall sales tax rate of the order.
        /// </summary>
        [JsonProperty("rate")]
        public double Rate { get; set; }

        /// <summary>
        /// A flag indicating whether or not there is an address on file for the order.
        /// </summary>
        [JsonProperty("has_nexus")]
        public bool HasNexus { get; set; }

        /// <summary>
        /// Freight taxability for the order.
        /// </summary>
        [JsonProperty("freight_taxable")]
        public bool IsFreightTaxable { get; set; }

        /// <summary>
        /// Origin-based or destination-based sales tax collection.
        /// </summary>
        [JsonProperty("tax_source")]
        public string TaxSource { get; set; }

        /// <summary>
        /// Jurisdiction names for the order.
        /// </summary>
        [JsonProperty("jurisdictions")]
        public Jurisdiction Jurisdiction { get; set; }

        /// <summary>
        /// Breakdown of rates by jurisdiction for the order, shipping, and individual
        /// line items. If <see cref="HasNexus"/> is false or no line items
        /// was provided, no breakdown is returned.
        /// </summary>
        [JsonProperty("breakdown")]
        public TaxesBreakdown Breakdown { get; set; }
    }
}