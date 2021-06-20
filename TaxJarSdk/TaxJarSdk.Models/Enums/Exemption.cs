namespace TaxJarSdk.Models.Requests
{
    /// <summary>
    /// Represents types of order exemptions.
    /// </summary>
    public enum Exemption
    {
        NonExempt = 0,
        Wholesale = 1,
        Government = 2,
        Marketplace = 3,
        Other = 4,
    }
}