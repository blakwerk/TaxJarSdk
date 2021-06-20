namespace TaxJarSdk.Tests.Clients
{
    using System;
    using Microsoft.Extensions.Logging.Abstractions;
    using Moq;
    using RestSharp;
    using TaxJarSdk.Implementation.Clients;
    using TaxJarSdk.Models.Requests;
    using TaxJarSdk.Tests.Fakes;
    using Xunit;

    public class TaxClientTests
    {
        [Fact]
        public void TaxClient_ThrowArgumentNullException_WhenLoggerIsNull()
        {
            // Arrange
            var restClientMock = new Mock<IRestClient>();
            var fakeConfig = FakeConfigurationProvider.BuildDefaultConfiguration();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxClient(logger: null, restClientMock.Object, fakeConfig));
        }

        [Fact]
        public void TaxClient_ThrowArgumentNullException_WhenRestClientIsNull()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxClient>();
            var fakeConfig = FakeConfigurationProvider.BuildDefaultConfiguration();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxClient(stubLogger, client: null, fakeConfig));
        }

        [Fact]
        public void TaxClient_ThrowArgumentNullException_WhenConfigurationIsNull()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxClient>();
            var restClientMock = new Mock<IRestClient>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxClient(stubLogger, restClientMock.Object, config: null));
        }

        [Fact]
        public void GetTaxRateForLocationAsync_NeverThrowsException()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxClient>();
            var restClientMock = new Mock<IRestClient>();
            var fakeConfig = FakeConfigurationProvider.BuildDefaultConfiguration();

            var request = new TaxRateRequest();

            var dut = new TaxClient(
                stubLogger,
                restClientMock.Object,
                fakeConfig);

            // Act
            var rate = dut.GetTaxRateAsync(request).Result;

            // Assert
            // if we made it here, test has passed.
        }
    }
}
