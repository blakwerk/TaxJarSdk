namespace TaxJarSdk.Models.Responses
{
    using TaxJarSdk.Models;

    /// <summary>
    /// Represents a base response.
    /// </summary>
    public abstract class BaseResponse : IResponse
    {
        /// <inheritdoc />
        public IError Error { get; set; } = null;
    }
}