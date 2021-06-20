namespace TaxJarSdk.Models
{
    /// <summary>
    /// Specifies the properties of a location.
    /// </summary>
    public interface ILocation
    {
        /// <summary>
        /// Gets the zip 
        /// </summary>
        string ZipCode { get; }

        /// <summary>
        /// Gets the country
        /// </summary>
        string Country { get; }

        /// <summary>
        /// Gets the state
        /// </summary>
        string State { get; }

        /// <summary>
        /// Gets the city
        /// </summary>
        string City { get; }

        /// <summary>
        /// Gets the street
        /// </summary>
        string Street { get; }
    }
}