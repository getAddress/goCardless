using getAddress.GoCardless.Common;
using getAddress.GoCardless.Common.Ids;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace getAddress.GoCardless.Api.Responses
{
    internal class CustomerResponseSingle
    {
        private CustomerResponseSingle()
        {

        }

        [JsonProperty("customers")]
        public CustomerResponse Customer { get; internal set; }
    }

    internal class CustomerResponseMultiple
    {
        private CustomerResponseMultiple()
        {

        }

        [JsonProperty("customers")]
        public CustomerResponse[] Customers { get; internal set; }
    }

    public class CustomerResponse : ResponseBase, ICustomerId
    {
        private CustomerResponse()
        {

        }

        internal GoCardlessApi Api { get; set; }

        public CustomerId CustomerId { get { return new CustomerId(this.Id); } }

        [JsonProperty("email")]
        public string Email { get; internal set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; internal set; }
        
        [JsonProperty("country_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCode CountryCode { get; internal set; }

        [JsonProperty("given_name")]
        public string GivenName { get; internal set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; internal set; }

        [JsonProperty("address_line1")]
        public string AddressLine1 { get; internal set; }

        [JsonProperty("address_line2")]
        public string AddressLine2 { get; internal set; }

        [JsonProperty("address_line3")]
        public string AddressLine3 { get; internal set; }

        [JsonProperty("city")]
        public string City { get; internal set; }

        [JsonProperty("region")]
        public string Region { get; internal set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; internal set; }

        [JsonProperty("language")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Language Language { get; internal set; }

        
    }
}
