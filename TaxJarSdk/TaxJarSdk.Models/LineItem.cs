namespace TaxJarSdk.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an order line item.
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// Unique identifier of the given line item.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get;set; }

        /// <summary>
        /// Quantity for the item.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get;set; }

        /// <summary>
        /// Product tax code for the item. If omitted, the item will remain fully taxable.
        /// </summary>
        [JsonProperty("product_tax_code")]
        public string ProductTaxCode { get;set; }

        /// <summary>
        /// Unit price for the item.
        /// </summary>
        [JsonProperty("unit_price")]
        public double UnitPrice { get;set; }

        /// <summary>
        /// Total discount (non-unit) for the item.
        /// </summary>
        [JsonProperty("discount")]
        public double Discount { get;set; }
    }
}