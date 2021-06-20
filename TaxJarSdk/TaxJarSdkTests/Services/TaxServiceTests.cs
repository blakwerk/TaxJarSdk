namespace TaxJarSdk.Tests.Services
{
    using System;
    using Microsoft.Extensions.Logging.Abstractions;
    using Moq;
    using TaxJarSdk.Core.Services;
    using TaxJarSdk.Implementation.Services;
    using Xunit;

    public class TaxServiceTests
    {
        [Fact]
        public void TaxService_ThrowsArgumentNullException_WhenLoggerIsNull()
        {
            // Arrange
            var taxClientMock = new Mock<ITaxCalculator>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxService(
                    logger: null, 
                    taxClientMock.Object));
        }

        [Fact]
        public void TaxService_ThrowsArgumentNullException_WhenClientIsNull()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxService>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxService(
                    stubLogger, 
                    taxClient: null));
        }
    }
}
