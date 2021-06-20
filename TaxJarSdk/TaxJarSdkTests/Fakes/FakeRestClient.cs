namespace TaxJarSdk.Tests.Fakes
{
    using Moq;
    using RestSharp;
    using System.Collections.Generic;

    internal class FakeRestClient
    {
        public static IRestClient GetDefaultRestClient()
        {
            return GetDefaultRestClientMock().Object;
        }

        public static Mock<IRestClient> GetDefaultRestClientMock()
        {
            var restClientMock = new Mock<IRestClient>();
            var defaultParametersMock = new Mock<IList<Parameter>>();

            restClientMock.SetupGet(r => r.DefaultParameters)
                .Returns(defaultParametersMock.Object);

            return restClientMock;
        }
    }
}
