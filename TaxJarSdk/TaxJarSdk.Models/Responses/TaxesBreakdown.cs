namespace TaxJarSdk.Models.Responses
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a breakdown of the taxes
    /// </summary>
    public class TaxesBreakdown
    {
        /// <summary>
        /// Total amount of the order to be taxed.
        /// </summary>
        [JsonProperty("taxable_amount")]
        public double TaxableAmount { get; set; }

        /// <summary>
        /// Total amount of sales tax to collect.
        /// </summary>
        [JsonProperty("tax_collectable")]
        public double TaxCollectable { get; set; }

        /// <summary>
        /// Overall sales tax rate of the breakdown which includes state, county, city
        /// and district tax for the order and shipping if applicable.
        /// </summary>
        [JsonProperty("combined_tax_rate")]
        public double CombinedTaxRate { get; set; }

        /// <summary>
        /// Amount of the order to be taxed at the state tax rate.
        /// </summary>
        [JsonProperty("state_taxable_amount")]
        public double StateTaxableAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("state_tax_rate")]
        public double StateTaxRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("state_tax_collectable")]
        public double StateTaxCollectable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("county_taxable_amount")]
        public double CountyTaxableAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("county_tax_rate")]
        public double CountyTaxRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("county_tax_collectable")]
        public double CountyTaxCollectable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("city_taxable_amount")]
        public double CityTaxableAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("city_tax_rate")]
        public double CityTaxRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("city_tax_collectable")]
        public double CityTaxCollectable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("special_district_taxable_amount")]
        public double SpecialDistrictTaxableAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("special_tax_rate")]
        public double SpecialTaxRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("special_district_tax_collectable")]
        public double SpecialDistrictTaxCollectable { get; set; }

        /// <summary>
        /// Breakdown of shipping rates if applicable.
        /// </summary>
        [JsonProperty("shipping")]
        public string Shipping { get; set; }

        /// <summary>
        /// Amount of the order to be taxed at the GST rate.
        /// </summary>
        [JsonProperty("gst_taxable_amount")]
        public double GstTaxableAmount { get; set; }

        /// <summary>
        /// Goods and services tax rate for given location.
        /// </summary>
        [JsonProperty("gst_tax_rate")]
        public double GstTaxRate { get; set; }

        /// <summary>
        /// Amount of goods and services tax to collect for given location.
        /// </summary>
        [JsonProperty("gst")]
        public double Gst { get; set; }

        /// <summary>
        /// Amount of the order to be taxed at the PST rate.
        /// </summary>
        [JsonProperty("pst_taxable_amount")]
        public double PstTaxableAmount { get; set; }

        /// <summary>
        /// Provincial sales tax rate for given location.
        /// </summary>
        [JsonProperty("pst_tax_rate")]
        public double PstTaxRate { get; set; }

        /// <summary>
        /// Amount of provincial sales tax to collect for given location.
        /// </summary>
        [JsonProperty("pst")]
        public double Pst { get; set; }

        /// <summary>
        /// Amount of the order to be taxed at the QST rate.
        /// </summary>
        [JsonProperty("qst_taxable_amount")]
        public double QstTaxableAmount { get; set; }

        /// <summary>
        /// Quebec sales tax rate for given location.
        /// </summary>
        [JsonProperty("qst_tax_rate")]
        public double QstTaxRate { get; set; }

        /// <summary>
        /// Amount of Quebec sales tax to collect for given location.
        /// </summary>
        [JsonProperty("qst")]
        public double Qst { get; set; }

        /// <summary>
        /// Amount of the order to be taxed at the country tax rate.
        /// </summary>
        [JsonProperty("country_taxable_amount")]
        public double CountryTaxableAmount { get; set; }

        /// <summary>
        /// Country sales tax rate for given location
        /// </summary>
        [JsonProperty("country_tax_rate")]
        public double CountryTaxRate { get; set; }

        /// <summary>
        /// Amount of sales tax to collect for the country. (EU/Australia)
        /// </summary>
        [JsonProperty("country_tax_collectable")]
        public double CountryTaxCollectable { get; set; }

        /// <summary>
        /// Breakdown of rates by line item if applicable.
        /// </summary>
        [JsonProperty("line_items")]
        public IEnumerable<LineItem> LineItems { get; set; }
    }
}