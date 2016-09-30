using getAddress.GoCardless.Common;
using getAddress.GoCardless.Common.Ids;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;

namespace getAddress.GoCardless.Api.Responses
{
    internal class CustomerResponseSingle
    {
        internal CustomerResponseSingle()
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
        private string originalEmail = null;
        private string email = null;

        private string originalCompanyName = null;
        private string companyName = null;

        private string originalCity = null;
        private string city = null;

        private CustomerResponse()
        {

        }

        [JsonIgnore]
        internal GoCardlessApi Api { get; set; }

        [JsonIgnore]
        public CustomerId CustomerId { get { return new CustomerId(this.Id); } }

        [JsonProperty("email")]
        public string Email {
            get { return email; }
            set
            {
                if (value != null) email = value;
                if (originalEmail == null) originalEmail = email;
            }
        }

        public bool ShouldSerializeEmail()
        {
            if (email == null) return false;

            return email != originalEmail;
        }

        internal void ResetOriginalProperties()
        {
            originalEmail = email;//todo:
        }

        [JsonProperty("company_name")]
        public string CompanyName {

            get { return companyName; }
            set
            {
                if (value != null) companyName = value;
                if (originalCompanyName == null) originalCompanyName = companyName;
            }
        }

        public bool ShouldSerializeCompanyName()
        {
            if (companyName == null) return false;

            return companyName != originalCompanyName;
        }

        [JsonProperty("country_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCode CountryCode { get; internal set; }

        public bool ShouldSerializeCountryCode()
        {
            return false;
        }

        [JsonProperty("given_name")]
        public string GivenName { get; internal set; }

        public bool ShouldSerializeGivenName()
        {
            return false;
        }

        [JsonProperty("family_name")]
        public string FamilyName { get; internal set; }

        public bool ShouldSerializeFamilyName()
        {
            return false;
        }

        [JsonProperty("address_line1")]
        public string AddressLine1 { get; internal set; }

        public bool ShouldSerializeAddressLine1()
        {
            return false;
        }

        [JsonProperty("address_line2")]
        public string AddressLine2 { get; internal set; }

        public bool ShouldSerializeAddressLine2()
        {
            return false;
        }

        [JsonProperty("address_line3")]
        public string AddressLine3 { get; internal set; }

        public bool ShouldSerializeAddressLine3()
        {
            return false;
        }

        [JsonProperty("city")]
        public string City {
            get { return city; }
            set
            {
                if (value != null) city = value;
                if (originalCity == null) originalCity = city;
            }
        }

        public bool ShouldSerializeCity()
        {
            if (city == null) return false;

            return city != originalCity;
        }

        [JsonProperty("region")]
        public string Region { get; internal set; }

        public bool ShouldSerializeRegion()
        {
            return false;
        }

        [JsonProperty("postal_code")]
        public string PostalCode { get; internal set; }

        public bool ShouldSerializePostalCode()
        {
            return false;
        }

        [JsonProperty("language")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Language Language { get; internal set; }

        public bool ShouldSerializeLanguage()
        {
            return false;
        }

        public async Task Update()
        {
            await Update(Api, this);
        }
        public static async Task Update(GoCardlessApi api, CustomerResponse customer)
        {
             await api.Customer.Update(customer);
        }
    }
}
