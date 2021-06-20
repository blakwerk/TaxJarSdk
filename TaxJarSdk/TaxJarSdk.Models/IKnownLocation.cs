namespace TaxJarSdk.Models
{
    /// <summary>
    /// Represents a known location, such as an address on file.
    /// </summary>
    public interface IKnownLocation : ILocation
    {
        /// <summary>
        /// Gets the id of the known location.
        /// </summary>
        string Id { get; }
    }
}