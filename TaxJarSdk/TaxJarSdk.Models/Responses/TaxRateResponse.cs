namespace TaxJarSdk.Models.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a response from the tax rate endpoint, with
    /// rates for a given location broken down by state,
    /// country, city, and district. For international requests,
    /// returns standard and reduced rates.
    /// </summary>
    public class TaxRateResponse : BaseResponse
    {
        /// <summary>
        /// Wrapper for the tax rate response data
        /// </summary>
        public InternalTaxRateResponse Rate { get; set; }
    }

    /// <summary>
    /// Represents a response from the tax rate endpoint, with
    /// rates for a given location broken down by state,
    /// country, city, and district. For international requests,
    /// returns standard and reduced rates.
    /// </summary>
    public class InternalTaxRateResponse 
    {
        // US, CANADA, AUS (sorry brits) PROPERTIES

        /// <summary>
        /// Postal code for given location.
        /// </summary>
        [JsonProperty("zip")]
        public string Zip { get; set; }
        
        /// <summary>
        /// Country for given location if SST state.
        /// </summary>
        /// <remarks>
        /// Note: Streamlined sales tax project member states
        /// include: AR, GA, IN, IA, KS, KY, MI, MN, NE, NV, NJ,
        /// NC, ND, OK, RI, SD, UT, VT, WA, WV, WI, WY
        /// </remarks>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Country sales tax rate for given location if SST state.
        /// </summary>
        /// <remarks>
        /// Note: Streamlined sales tax project member states
        /// include: AR, GA, IN, IA, KS, KY, MI, MN, NE, NV, NJ,
        /// NC, ND, OK, RI, SD, UT, VT, WA, WV, WI, WY
        /// </remarks>
        [JsonProperty("country_rate")]
        public double CountryRate { get; set; }

        /// <summary>
        /// Postal abbreviated state name for given location.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// State sales tax rate for given location.
        /// </summary>
        [JsonProperty("state_rate")]
        public double StateRate { get; set; }

        /// <summary>
        /// County name for given location.
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// County sales tax rate for given location.
        /// </summary>
        [JsonProperty("county_rate")]
        public double CountyRate { get; set; }

        /// <summary>
        /// City name for given location.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// City sales tax rate for given location.
        /// </summary>
        [JsonProperty("city_rate")]
        public double CityRate { get; set; }

        /// <summary>
        /// Aggregate rate for all city and county sales tax districts
        /// effective at the location.
        /// </summary>
        [JsonProperty("combined_district_rate")]
        public double CombinedDistrictRate { get; set; }

        /// <summary>
        /// Overall sales tax rate which includes state, county, city
        /// and district tax. This rate should be used to determine
        /// how much sales tax to collect for an order.
        /// </summary>
        [JsonProperty("combined_rate")]
        public double CombinedRate { get; set; }

        /// <summary>
        /// Freight taxability for given location.
        /// </summary>
        [JsonProperty("freight_taxable")]
        public bool IsFreightTaxable { get; set; }

        // Extra EU Properties:

        /// <summary>
        /// Country name for given location.
        /// </summary>
        [JsonProperty("name")]
        public bool EuCountryName { get; set; }

        /// <summary>
        /// Standard rate for given location.
        /// </summary>
        [JsonProperty("standard_rate")]
        public double StandardRate { get; set; }

        /// <summary>
        /// Reduced rate for given location.
        /// </summary>
        [JsonProperty("reduced_rate")]
        public double ReducedRate { get; set; }

        /// <summary>
        /// Super reduced rate for given location.
        /// </summary>
        [JsonProperty("super_reduced_rate")]
        public double SuperReducedRate { get; set; }

        /// <summary>
        /// Parking rate for given location.
        /// </summary>
        [JsonProperty("parking_rate")]
        public double ParkingRate { get; set; }

        /// <summary>
        /// Distance selling threshold for given location.
        /// </summary>
        [JsonProperty("distance_sale_threshold")]
        public double DistanceSaleThreshold { get; set; }
    }
}
