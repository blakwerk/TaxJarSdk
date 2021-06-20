namespace TaxJarSdk.Tests.Fakes
{
    using TaxJarSdk.Models.Requests;
    using TaxJarSdk.Models.Responses;

    public class DummyData
    {
        public static TaxRateRequest SantaMonicaRateRequest { get; } = new()
        {
            City = "Santa Monica",
            State = "CA",
            ZipCode = "90404",
        };

        public static TaxRateResponse SantaMonicaTaxRateResponse { get; } = new()
        {
            Rate = new InternalTaxRateResponse
            {
                Zip = "90404",
                State = "CA",
                StateRate = 0.0625,
                County = "LOS ANGELES",
                CountyRate = 0.01,
                City = "SANTA MONICA",
                CityRate = 0.0,
                CombinedDistrictRate = 0.03,
                CombinedRate = 0.1025,
                IsFreightTaxable = false,
            },
        };

        public static string SantaMonicaRateRequestBody { get; } = "{\"zip\":\"90404\",\"country\":\"US\",\"state\":\"CA\",\"city\":\"Santa Monica\",\"street\":null}";

        //TaxRateResponse
        public static string SantaMonicaRateResponseJson { get; } = "{\"rate\":{\"zip\":\"90404\",\"country\":\"US\",\"country_rate\":\"0.0\",\"state\":\"CA\",\"state_rate\":\"0.0625\",\"county\":\"LOS ANGELES\",\"county_rate\":\"0.01\",\"city\":\"SANTA MONICA\",\"city_rate\":\"0.0\",\"combined_district_rate\":\"0.03\",\"combined_rate\":\"0.1025\",\"freight_taxable\":false}}";
    }
}