namespace TaxJarSdk.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a nexus address - an address on file.
    /// </summary>
    public class NexusAddress : IKnownLocation
    {
        /// <summary>
        /// The location id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get;set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("country")]
        public string Country { get;set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("zip")]
        public string ZipCode { get;set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("state")]
        public string State { get;set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("city")]
        public string City { get;set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("street")]
        public string Street { get;set; }
    }
}