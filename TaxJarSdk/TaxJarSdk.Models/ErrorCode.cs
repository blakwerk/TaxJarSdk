namespace TaxJarSdk.Models
{
    /// <summary>
    /// Contains common error codes.
    /// </summary>
    public static class ErrorCode
    {
        /// <summary>
        /// Indicates the request was not understood by the server.
        /// </summary>
        public const string BadRequest = "BadRequest";

        /// <summary>
        /// Indicates that the server refused to fulfill the request.
        /// </summary>
        public const string Forbidden = "ResourceForbiden";

        /// <summary>
        /// Indicates the request is not authorized for the resource.
        /// </summary>
        public const string ResourceNotAuthorized = "ResourceNotAuthorized";

        /// <summary>
        /// Indicates the resource could not be found.
        /// </summary>
        public const string ResourceNotFound = "ResourceNotFound";

        /// <summary>
        /// Indicates that the request is not acceptable.
        /// </summary>
        public const string RequestNotAcceptable = "RequestNotAcceptable";

        /// <summary>
        /// Indicates a problem on the server. 
        /// </summary>
        public const string InternalServerError = "InternalServerError";

        /// <summary>
        /// Indicates the request could not be found.
        /// </summary>
        public const string UnprocessableEntity = "UnprocessableEntity";

        /// <summary>
        /// Indicates that too many requests have been sent over a given amount of time.
        /// </summary>
        public const string TooManyRequests = "TooManyRequests";

        /// <summary>
        /// Indicates the server is temporarily offline. 
        /// </summary>
        public const string ServiceUnavailable = "ServiceUnavailable";
    }
}