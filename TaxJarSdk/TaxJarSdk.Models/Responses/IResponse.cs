namespace TaxJarSdk.Models.Responses
{
    using TaxJarSdk.Models;

    /// <summary>
    /// Specifies common response elements.
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// Gets or sets the error 
        /// </summary>
        IError Error { get; set; }
    }
}