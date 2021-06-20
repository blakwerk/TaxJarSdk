namespace TaxJarSdk.Models
{
    using System.Collections.Generic;
    using TaxJarSdk.Models.Requests;

    /// <summary>
    /// Specifies an order.
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Gets the unique id for this order.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the from-location, the order's origination point.
        /// </summary>
        ILocation FromLocation { get; }

        /// <summary>
        /// Gets the to-location, the order's destination point.
        /// </summary>
        ILocation ToLocation { get; }

        /// <summary>
        /// Total amount of the order, excluding shipping.
        /// </summary>
        double Amount { get; }

        /// <summary>
        /// Total amount of shipping for the order.
        /// </summary>
        double Shipping { get; }

        /// <summary>
        /// Unique identifier of the given customer for exemptions.
        /// </summary>
        string CustomerId { get; }

        /// <summary>
        /// Type of exemption for the order: wholesale, government, marketplace, other, or non_exempt.
        /// </summary>
        Exemption Exemption { get; }

        /// <summary>
        /// Gets the collection of known addresses (addresses on file). 
        /// </summary>
        IEnumerable<IKnownLocation> KnownLocations { get; }

        /// <summary>
        /// Gets the line items. 
        /// </summary>
        IEnumerable<LineItem> LineItems { get; }
    }
}