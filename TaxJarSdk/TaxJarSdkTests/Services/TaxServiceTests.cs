namespace TaxJarSdk.Tests.Services
{
    using System;
    using System.Net;
    using Microsoft.Extensions.Logging.Abstractions;
    using Moq;
    using TaxJarSdk.Core.Services;
    using TaxJarSdk.Implementation.Services;
    using TaxJarSdk.Models.Extensions;
    using TaxJarSdk.Models.Requests;
    using TaxJarSdk.Models.Responses;
    using TaxJarSdk.Tests.Fakes;
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
        public void GetTaxRateForLocationAsync_WhenInvalidPostRequest_ReturnsNaN()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxService>();
            var taxClientMock = new Mock<ITaxClient>();
            var taxCalculatorMock = new Mock<ITaxCalculator>();

            var errorResponse = HttpStatusCode.NotFound.ToErrorResponse<TaxRateResponse>();

            taxClientMock.Setup(c => c.GetTaxRateAsync(It.IsAny<TaxRateRequest>()))
                .ReturnsAsync(errorResponse);

            var dut = new TaxService(
                stubLogger,
                taxClientMock.Object,
                taxCalculatorMock.Object);

            // Act
            var rate = dut.GetTaxRateForLocationAsync(DummyData.SantaMonicaRateRequest).Result;

            // Assert
            Assert.Equal(double.NaN, rate);
        }

        [Fact]
        public void GetTaxRateForLocationAsync_WhenInvalidGetRequest_ReturnsNaN()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxService>();
            var taxClientMock = new Mock<ITaxClient>();
            var taxCalculatorMock = new Mock<ITaxCalculator>();

            var errorResponse = HttpStatusCode.NotFound.ToErrorResponse<TaxRateResponse>();

            taxClientMock.Setup(c => c.GetTaxRateAsync(It.IsAny<string>()))
                .ReturnsAsync(errorResponse);

            var dut = new TaxService(
                stubLogger,
                taxClientMock.Object,
                taxCalculatorMock.Object);

            // Act
            var rate = dut.GetTaxRateForLocationAsync("some zip code").Result;

            // Assert
            Assert.Equal(double.NaN, rate);
        }
    }
}
