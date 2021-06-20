namespace TaxJarSdk.Models
{
    using System;

    /// <summary>
    /// Contains information about common errors.
    /// </summary>
    public class Error : IError
    {
        public string Code { get; set; }

        public string Message { get; set; }
        
        public Exception Exception { get; set; }
    }
}