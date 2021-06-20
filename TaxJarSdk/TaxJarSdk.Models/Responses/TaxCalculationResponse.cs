namespace TaxJarSdk.Models.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a response from a tax calculation api
    /// </summary>
    public class TaxCalculationResponse : BaseResponse
    {
        [JsonProperty("tax")]
        public TaxResponse Taxes { get; set; }
    }
}
