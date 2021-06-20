namespace TaxJarSdk.Models.Requests
{
    using Newtonsoft.Json;

    public class TaxRateRequest : ILocation //: BaseRequest
    {
        /// <summary>
        /// Gets or sets the zip code. This is a required property.
        /// </summary>
        /// <remarks>
        /// Proper format is 5-digit ZIP, or ZIP+4.
        /// </remarks>
        [JsonProperty("zip")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the two-letter ISO country code. 
        /// </summary>
        /// <remarks>
        /// This property defaults to 'US', and is required for all non-US locations.
        /// </remarks>
        [JsonProperty("country")]
        public string Country { get; set; } = "US";

        /// <summary>
        /// Gets or sets the two-letter ISO state code for the given location.
        /// This property is optional.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the city for the given location.
        /// This property is optional.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets te street address for the given location.
        /// This property is optional.
        /// </summary>
        /// <remarks>
        /// Note: Street address provides more accurate calculations for
        /// the following states: AR, AZ, CA, CO, CT, DC, FL, GA,
        /// HI, IA, ID, IN, KS, KY, LA, MA, MD, ME, MI, MN, MO, MS,
        /// NC, ND, NE, NJ, NM, NV, NY, OH, OK, PA, RI, SC, SD, TN,
        /// TX, UT, VA, VT, WA, WI, WV, WY
        /// </remarks>
        [JsonProperty("street")]
        public string Street { get; set; }

        ///// <inheritdoc />
        //public override bool AreRequirementsMet()
        //{
        //    if (string.IsNullOrWhiteSpace(this.ZipCode))
        //    {
        //        return false;
        //    }

        //    if (this.ZipCode.Length != 5 || this.ZipCode.Length != 9)
        //    {
        //        return false;
        //    }

        //    if (this.Country.Length != 2)
        //    {
        //        return false;
        //    }
        //}
    }

    // TODO map this to an interface?
    public abstract class BaseRequest
    {
        /// <summary>
        /// Some endpoints require certain pieces of data. This method
        /// evaluates the data properties for the given request.
        /// </summary>
        /// <returns>
        /// Returns a flag indicating if the requirements are met.
        /// </returns>
        public abstract bool AreRequirementsMet();
    }
}
