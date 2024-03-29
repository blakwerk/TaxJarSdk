﻿namespace TaxJarSdk.Tests.Services
{
    using System;
    using System.Net;
    using Microsoft.Extensions.Logging.Abstractions;
    using Moq;
    using TaxJarSdk.Core.Clients;
    using TaxJarSdk.Implementation.Services;
    using TaxJarSdk.Models;
    using TaxJarSdk.Models.Extensions;
    using TaxJarSdk.Models.Requests;
    using TaxJarSdk.Models.Responses;
    using TaxJarSdk.Tests.Fakes;
    using Xunit;

    public class TaxCalculatorTests
    {
        [Fact]
        public void TaxCalculator_ThrowsArgumentNullException_WhenLoggerIsNull()
        {
            // Arrange
            var taxClientMock = new Mock<ITaxClient>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxCalculator(
                    logger: null, 
                    taxClientMock.Object));
        }

        [Fact]
        public void TaxCalculator_ThrowsArgumentNullException_WhenClientIsNull()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxCalculator>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxCalculator(
                    stubLogger, 
                    taxClient: null));
        }

        [Fact]
        public void GetTaxRateForLocationAsync_WhenInvalidPostRequest_ReturnsNaN()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxCalculator>();
            var taxClientMock = new Mock<ITaxClient>();
            var errorResponse = HttpStatusCode.NotFound.ToErrorResponse<TaxRateResponse>();

            taxClientMock.Setup(c => c.GetTaxRateAsync(It.IsAny<TaxRateRequest>()))
                .ReturnsAsync(errorResponse);

            var dut = new TaxCalculator(
                stubLogger,
                taxClientMock.Object);

            // Act
            var rate = dut.GetTaxRateForLocationAsync(DummyData.SantaMonicaRateRequest).Result;

            // Assert
            Assert.Equal(double.NaN, rate);
        }

        [Fact]
        public void GetTaxRateForLocationAsync_WhenInvalidGetRequest_ReturnsNaN()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxCalculator>();
            var taxClientMock = new Mock<ITaxClient>();

            var errorResponse = HttpStatusCode.NotFound.ToErrorResponse<TaxRateResponse>();

            taxClientMock.Setup(c => c.GetTaxRateAsync(It.IsAny<string>()))
                .ReturnsAsync(errorResponse);

            var dut = new TaxCalculator(
                stubLogger,
                taxClientMock.Object);

            // Act
            var rate = dut.GetTaxRateForLocationAsync("some zip code").Result;

            // Assert
            Assert.Equal(double.NaN, rate);
        }

        [Fact]
        public void CalculateTaxesAsync_WhenInvalidRequest_ReturnsNan()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxCalculator>();
            var taxClientMock = new Mock<ITaxClient>();

            var errorResponse = HttpStatusCode.NotFound.ToErrorResponse<TaxCalculationResponse>();

            taxClientMock
                .Setup(c => c.CalculateSalesTaxAsync(
                    It.IsAny<TaxCalculationRequest>()))
                .ReturnsAsync(errorResponse);

            var dut = new TaxCalculator(
                stubLogger,
                taxClientMock.Object);

            // Act
            var taxes = dut.CalculateTaxesAsync(new Order()).Result;

            // Assert
            Assert.Equal(double.NaN, taxes);
        }

        [Fact]
        public void CalculateTaxesAsync_WhenValidRequest_ReturnsExpectedTax()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxCalculator>();
            var taxClientMock = new Mock<ITaxClient>();

            var expectedTaxes = 1.50;
            var apiResponse = new TaxCalculationResponse
            {
                Taxes = new TaxResponse
                {
                    TaxAmountToCollect = expectedTaxes,
                }
            };

            taxClientMock
                .Setup(c => c.CalculateSalesTaxAsync(
                    It.IsAny<TaxCalculationRequest>()))
                .ReturnsAsync(apiResponse);

            var dut = new TaxCalculator(
                stubLogger,
                taxClientMock.Object);

            // Act
            var actualTaxes = dut.CalculateTaxesAsync(new Order()).Result;

            // Assert
            Assert.Equal(expectedTaxes, actualTaxes);
        }
    }
}
