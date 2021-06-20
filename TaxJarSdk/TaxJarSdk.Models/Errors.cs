namespace TaxJarSdk.Models
{
    /// <summary>
    /// Contains common errors.
    /// </summary>
    public static class Errors
    {
        /// <summary>
        /// Indicates the resource could not be found.
        /// </summary>
        public static Error ResourceNotFound(string message = null)
        {
            return new()
            {
                Code = ErrorCode.ResourceNotFound,
                Message = message,
            };
        }

        /// <summary>
        /// Indicates the request is not authorized for the resource.
        /// </summary>
        public static Error ResourceNotAuthorized(string message = null)
        {
            return new()
            {
                Code = ErrorCode.ResourceNotAuthorized,
                Message = message,
            };
        }

        /// <summary>
        /// Indicates the request was not understood by the server.
        /// </summary>
        public static Error BadRequest(string message = null)
        {
            return new()
            {
                Code = ErrorCode.BadRequest,
                Message = message,
            };
        }

        /// <summary>
        /// Indicates that the request is not acceptable.
        /// </summary>
        public static Error NotAcceptable(string message = null)
        {
            return new()
            {
                Code = ErrorCode.RequestNotAcceptable,
                Message = message,
            };
        }

        /// <summary>
        /// Indicates the request could not be found.
        /// </summary>
        public static Error UnprocessableEntity(string message = null)
        {
            return new()
            {
                Code = ErrorCode.UnprocessableEntity,
                Message = message,
            };
        }

        /// <summary>
        /// Indicates that too many requests have been sent over a given amount of time.
        /// </summary>
        public static Error TooManyRequests(string message = null)
        {
            return new()
            {
                Code = ErrorCode.TooManyRequests,
                Message = message,
            };
        }

        /// <summary>
        /// Indicates a problem on the server. 
        /// </summary>
        public static Error InternalServerError(string message = null)
        {
            return new()
            {
                Code = ErrorCode.InternalServerError,
                Message = message,
            };
        }

        /// <summary>
        /// Indicates the server is temporarily offline. 
        /// </summary>
        public static Error ServiceUnavailable(string message = null)
        {
            return new()
            {
                Code = ErrorCode.ServiceUnavailable,
                Message = message,
            };
        }

        /// <summary>
        /// Indicates that the server refused to fulfill the request.
        /// </summary>
        public static Error Forbidden(string message = null)
        {
            return new()
            {
                Code = ErrorCode.Forbidden,
                Message = message,
            };
        }
    }
}