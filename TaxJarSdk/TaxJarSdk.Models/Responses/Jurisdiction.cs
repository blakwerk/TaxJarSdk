namespace TaxJarSdk.Models.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a tax jurisdiction.
    /// </summary>
    public class Jurisdiction
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("State")]
        public string State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("county")]
        public string County { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("City")]
        public string City { get; set; }
    }
}