namespace TaxJarSdk.Models.Extensions
{
    using System.Net;
    using TaxJarSdk.Models.Responses;

    /// <summary>
    /// Extension methods for <see cref="HttpStatusCode"/>s
    /// </summary>
    public static class HttpStatusCodeExtensions
    {
        /// <summary>
        /// Creates a response with a populated error based on the status code.
        /// </summary>
        public static TResponse ToErrorResponse<TResponse>(
            this HttpStatusCode self, 
            IError defaultOverride = null) where TResponse : IResponse, new()
        {
            TResponse response;
            switch (self)
            {
                case HttpStatusCode.NotFound:
                    response = new TResponse
                    {
                        Error = Errors.ResourceNotFound(),
                    };
                    break;

                case HttpStatusCode.Unauthorized:
                    response = new TResponse
                    {
                        Error = Errors.ResourceNotAuthorized(),
                    };
                    break;

                case HttpStatusCode.Forbidden:
                    response = new TResponse
                    {
                        Error = Errors.Forbidden(),
                    };
                    break;

                case HttpStatusCode.BadRequest:
                    response = new TResponse
                    {
                        Error = Errors.BadRequest(),
                    };
                    break;

                case HttpStatusCode.NotAcceptable:
                    response = new TResponse
                    {
                        Error = Errors.NotAcceptable(),
                    };
                    break;

                case HttpStatusCode.UnprocessableEntity:
                    response = new TResponse
                    {
                        Error = Errors.UnprocessableEntity(),
                    };
                    break;

                case HttpStatusCode.TooManyRequests:
                    response = new TResponse
                    {
                        Error = Errors.TooManyRequests(),
                    };
                    break;

                case HttpStatusCode.InternalServerError:
                    response = new TResponse
                    {
                        Error = Errors.InternalServerError(),
                    };
                    break;

                case HttpStatusCode.ServiceUnavailable:
                    response = new TResponse
                    {
                        Error = Errors.ServiceUnavailable(),
                    };
                    break;

                default:
                    if (defaultOverride != null)
                    {
                        response = new TResponse
                        {
                            Error = defaultOverride,
                        };
                    }
                    else
                    {
                        response = new TResponse
                        {
                            Error = Errors.InternalServerError(),
                        };
                    }
                    break;
            }

            return response;
        }
    }
}
