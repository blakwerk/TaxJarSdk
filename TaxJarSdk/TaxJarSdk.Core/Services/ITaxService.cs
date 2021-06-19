namespace TaxJarSdk.Core.Services
{
    using System;
    using System.Threading.Tasks;

    public interface ITaxService
    {
        // Get tax rates for a location

        /// <summary>
        /// Uses a <see cref="ITaxCalculator"/> to calculate the taxes for the <see cref="IOrder"/>
        /// </summary>
        Task<double> CalculateTaxesAsync(IOrder order);
    }

    public interface ITaxCalculator
    {

    }

    public interface IResponse
    {
        /// <summary>
        /// Gets or sets the error 
        /// </summary>
        IServiceError ServiceError { get; set; }
    }

    public interface IServiceError
    {
        //TODO is this needed?
        public string Code { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }
    }

    public interface IOrder
    {
        /// <summary>
        /// Gets or sets the unique id for this order.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or set the country code for the order. This property is required.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the shipping cost for the order. This property is required.
        /// </summary>
        public double ShippingCost { get; set; }

        /// <summary>
        /// Gets or sets the amount. TODO required for now.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// A flag indicating whether or not the order is ready for tax calculation.
        /// </summary>
        public bool IsOrderReadyForCalculation { get; }
    }
}
