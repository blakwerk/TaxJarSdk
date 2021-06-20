namespace TaxJarSdk.Tests.Clients
{
    using System;
    using System.Net;
    using System.Threading;
    using Microsoft.Extensions.Logging.Abstractions;
    using Moq;
    using RestSharp;
    using TaxJarSdk.Implementation.Clients;
    using TaxJarSdk.Models;
    using TaxJarSdk.Models.Extensions;
    using TaxJarSdk.Models.Requests;
    using TaxJarSdk.Models.Responses;
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
                new TaxJarClient(logger: null, restClientMock.Object, fakeConfig));
        }

        [Fact]
        public void TaxClient_ThrowArgumentNullException_WhenRestClientIsNull()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxJarClient>();
            var fakeConfig = FakeConfigurationProvider.BuildDefaultConfiguration();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxJarClient(stubLogger, client: null, fakeConfig));
        }

        [Fact]
        public void TaxClient_ThrowArgumentNullException_WhenConfigurationIsNull()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxJarClient>();
            var restClientMock = new Mock<IRestClient>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new TaxJarClient(stubLogger, restClientMock.Object, config: null));
        }
    }

    public class BaseClientTests
    {
        [Fact]
        public void PostAsync_WithBadRequest_ReturnsErrorResponse()
        {
            // Arrange
            var stubLogger = new NullLogger<BaseClient>();
            var restClient = FakeRestClient.GetDefaultRestClient();
            var fakeConfig = FakeConfigurationProvider.BuildDefaultConfiguration();

            var expectedErrorCode = Errors.InternalServerError().Code;

            var dut = new TestableBaseClientWrapper(
                stubLogger,
                restClient,
                fakeConfig);

            // Act
            var response = dut.PostAsync<TaxRateRequest, TaxRateResponse>(null, null).Result;

            // Assert
            Assert.Equal(expectedErrorCode, response.Error.Code);
        }

        [Fact]
        public void GetAsync_WithBadRequest_ReturnsErrorResponse()
        {
            // Arrange
            var stubLogger = new NullLogger<BaseClient>();
            var restClient = FakeRestClient.GetDefaultRestClient();
            var fakeConfig = FakeConfigurationProvider.BuildDefaultConfiguration();

            var expectedErrorCode = Errors.InternalServerError().Code;

            var dut = new TestableBaseClientWrapper(
                stubLogger,
                restClient,
                fakeConfig);

            // Act
            var response = dut.GetAsync<TaxRateResponse>("").Result;

            // Assert
            Assert.Equal(expectedErrorCode, response.Error.Code);
        }

        [Fact]
        public void GetAsync_UnsuccessfulRequest_ReturnsResponseWithError()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxJarClient>();
            var restClientMock = FakeRestClient.GetDefaultRestClientMock();
            var fakeConfig = FakeConfigurationProvider.BuildDefaultConfiguration();

            var expectedResponse = HttpStatusCode.BadRequest.ToErrorResponse<TaxRateResponse>();
            
            var restResponseMock = new Mock<IRestResponse<TaxRateResponse>>();
            restResponseMock.SetupGet(r => r.IsSuccessful)
                .Returns(false);
            restResponseMock.SetupGet(r => r.StatusCode)
                .Returns(HttpStatusCode.BadRequest);
            
            restClientMock.Setup(r => r.ExecuteGetAsync<TaxRateResponse>(It.IsAny<RestRequest>(), default))
                .ReturnsAsync(restResponseMock.Object);

            var dut = new TestableBaseClientWrapper(
                stubLogger,
                restClientMock.Object,
                fakeConfig);

            // Act
            var response = dut.GetAsync<TaxRateResponse>("path").Result;

            // Assert
            Assert.Equal(expectedResponse.Error.Code, response.Error.Code);
        }

        [Fact]
        public void GetAsync_ClientException_ReturnsResponseWithError()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxJarClient>();
            var restClientMock = FakeRestClient.GetDefaultRestClientMock();
            var fakeConfig = FakeConfigurationProvider.BuildDefaultConfiguration();

            // don't setup mocks so an exception is thrown during test

            var dut = new TestableBaseClientWrapper(
                stubLogger,
                restClientMock.Object,
                fakeConfig);

            // Act
            var response = dut.GetAsync<TaxRateResponse>("path").Result;

            // Assert
            Assert.NotNull(response.Error.Exception);
        }

        [Fact]
        public void GetAsync_SuccessfulRequest_ReturnsResponse()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxJarClient>();
            var restClientMock = FakeRestClient.GetDefaultRestClientMock();
            var fakeConfig = FakeConfigurationProvider.BuildDefaultConfiguration();

            var goodResponse = new TaxRateResponse();
            
            var restResponseMock = new Mock<IRestResponse<TaxRateResponse>>();
            restResponseMock.SetupGet(r => r.Data)
                .Returns(goodResponse);
            restResponseMock.SetupGet(r => r.IsSuccessful)
                .Returns(true);

            restClientMock.Setup(r => r.ExecuteGetAsync<TaxRateResponse>(It.IsAny<RestRequest>(), default))
                .ReturnsAsync(restResponseMock.Object);

            var dut = new TestableBaseClientWrapper(
                stubLogger,
                restClientMock.Object,
                fakeConfig);

            // Act
            var response = dut.GetAsync<TaxRateResponse>("path").Result;

            // Assert
            Assert.Equal(goodResponse, response);
        }
        
        [Fact (Skip = "Skip for now. RestClient isn't behaving")]
        public void PostAsync_SuccessfulRequest_ReturnsResponse()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxJarClient>();
            var restClientMock = FakeRestClient.GetDefaultRestClientMock();
            var fakeConfig = FakeConfigurationProvider.BuildDefaultConfiguration();

            var expectedResponseZip = "90404";

            var path = "path";

            restClientMock
                .Setup(r => r.ExecuteAsync(
                    It.Is<IRestRequest>( request => request.Method == Method.POST),
                    default(CancellationToken)))
                .ReturnsAsync(
                    new RestResponse
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = DummyData.SantaMonicaRateResponseJson,
                    });

            var dut = new TestableBaseClientWrapper(
                stubLogger,
                restClientMock.Object,
                fakeConfig);

            // Act
            var response = dut.PostAsync<TaxRateRequest, TaxRateResponse>(
                    path,
                    DummyData.SantaMonicaRateRequest)
                .Result;

            // Assert
            Assert.Equal(expectedResponseZip, response.Rate.Zip);
        }

        [Fact]
        public void PostAsync_InvalidRequest_ReturnsErrorResponse()
        {
            // Arrange
            var stubLogger = new NullLogger<TaxJarClient>();
            var restClientMock = FakeRestClient.GetDefaultRestClientMock();
            var fakeConfig = FakeConfigurationProvider.BuildDefaultConfiguration();
            
            var jsonBody = DummyData.SantaMonicaRateRequestBody;
            var restRequest = new RestRequest("path", Method.POST).AddJsonBody(jsonBody);
            restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            
            restClientMock
                .Setup(r => r.ExecuteAsync(
                    restRequest,
                    default(CancellationToken)))
                .ReturnsAsync(
                    new RestResponse
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = DummyData.SantaMonicaRateResponseJson,
                    });

            var dut = new TestableBaseClientWrapper(
                stubLogger,
                restClientMock.Object,
                fakeConfig);

            // Act
            var response = dut.PostAsync<TaxRateRequest, TaxRateResponse>(
                    "path",
                    new TaxRateRequest())
                .Result;

            // Assert
            Assert.NotNull(response.Error);
        }
    }
}
