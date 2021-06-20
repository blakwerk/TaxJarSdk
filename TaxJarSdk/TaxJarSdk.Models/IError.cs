namespace TaxJarSdk.Models
{
    using System;

    /// <summary>
    /// Specifies a format for common errors.
    /// </summary>
    public interface IError
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }
    }
}