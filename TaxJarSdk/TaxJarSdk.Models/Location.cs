namespace TaxJarSdk.Models
{
    public class Location : ILocation
    {
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the two-letter ISO country code. 
        /// </summary>
        public string Country { get; set; } = "US";

        /// <summary>
        /// Gets or sets the two-letter ISO state code for the given location.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the city for the given location.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets te street address for the given location.
        /// </summary>
        public string Street { get; set; }
    }
}
