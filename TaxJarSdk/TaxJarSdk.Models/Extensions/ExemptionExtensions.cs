namespace TaxJarSdk.Models.Requests
{
    public static class ExemptionExtensions
    {
        /// <summary>
        /// Gets the api parameter for the given Exemption.
        /// </summary>
        public static string ToApiString(this Exemption self)
        {
            switch (self)
            {
                case Exemption.Wholesale:
                    return "wholesale";

                case Exemption.Government:
                    return "government";

                case Exemption.Marketplace:
                    return "marketplace";

                case Exemption.Other:
                    return "other";

                default:
                    return "non_exempt";
            }
        }
    }
}