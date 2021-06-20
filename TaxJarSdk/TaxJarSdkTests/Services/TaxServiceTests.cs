namespace TaxJarSdk.Tests.Services
{
    using System;
    using Microsoft.Extensions.Logging.Abstractions;
    using Moq;
    using TaxJarSdk.Core.Services;
    using TaxJarSdk.Implementation.Services;
    using TaxJarSdk.Models.Requests;
    using TaxJarSdk.Models.Responses;
    using Xunit;

    public class TaxServiceTests
    {
        [Fact]
        public void TaxService_ThrowsArgumentNullException_WhenLoggerIsNull()
        {
            // Arrange
            var taxClientMock = new Mock<ITaxClient>();
            var taxCalculatorMock = new Mock<ITaxCalculator>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxService(
                    logger: null, 
                    taxClientMock.Object, 
                    taxCalculatorMock.Object));
        }

        [Fact]
        public void TaxService_ThrowsArgumentNullException_WhenClientIsNull()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxService>();
            var taxCalculatorMock = new Mock<ITaxCalculator>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxService(
                    stubLogger, 
                    taxClient: null, 
                    taxCalculatorMock.Object));
        }

        [Fact]
        public void TaxService_ThrowsArgumentNullException_WhenCalculatorIsNull()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxService>();
            var taxClientMock = new Mock<ITaxClient>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxService(
                    stubLogger, 
                    taxClientMock.Object, 
                    taxCalculator: null));
        }

        [Fact]
        public void GetTaxRateForLocationAsync_WhenInvalidRequest_ReturnsNaN()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxService>();
            var taxClientMock = new Mock<ITaxClient>();
            var taxCalculatorMock = new Mock<ITaxCalculator>();

            var dut = new TaxService(
                stubLogger,
                taxClientMock.Object,
                taxCalculatorMock.Object);

            // Act
            var rate = dut.GetTaxRateForLocationAsync(DummyData.SantaMonicaRateRequest).Result;

            // Assert
            Assert.Equal(double.NaN, rate);
        }
    }

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
            Zip = "90404",
            State = "CA",
            StateRate = 0.0625,
            County = "LOS ANGELES",
            CountyRate = 0.01,
            City = "SANTA MONICA",
            CityRate = 0.0,
            CombinedDistrictRate = 0.025,
            CombinedRate = 0.975,
            IsFreightTaxable = false,
        };

        //TaxRateResponse
        public static string SantaMonicaRateResponseJson { get; } 
            = @"{
  ""rate"": {
    ""zip"": ""90404"",
    ""state"": ""CA"",
    ""state_rate"": ""0.0625"",
    ""county"": ""LOS ANGELES"",
    ""county_rate"": ""0.01"",
    ""city"": ""SANTA MONICA"",
    ""city_rate"": ""0.0"",
    ""combined_district_rate"": ""0.025"",
    ""combined_rate"": ""0.0975"",
    ""freight_taxable"": false
  }
}";

    }
}
