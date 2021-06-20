namespace TaxJarSdk.Implementation.Extensions
{
    using System;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Extension methods for <see cref="IConfiguration"/>
    /// </summary>
    internal static class ConfigurationExtensions
    {
        /// <summary>
        /// Gets the api key from config
        /// </summary>
        public static string GetTaxJarApiKey(this IConfiguration self)
        { 
            return self.GetValue<string>("ApiKeys:TaxJarApiKey");
        }

        /// <summary>
        /// Gets the base api url for the tax api
        /// </summary>
        public static string GetTaxJarApiBase(this IConfiguration self)
        {
            return self.GetValue<string>("ApiBaseUrls:TaxJarApi");
        }
    }
}
