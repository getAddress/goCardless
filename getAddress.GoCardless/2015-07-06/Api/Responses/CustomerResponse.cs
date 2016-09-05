using Newtonsoft.Json;

namespace getAddress.GoCardless._2015_07_06.Api.Responses
{
    internal class CustomerResponseSingle
    {
        [JsonProperty("customers")]
        public CustomerResponse Customer { get; internal set; }
    }

    public class CustomerResponse : ResponseBase
    {

        [JsonProperty("email")]
        public string Email { get; internal set; }
    }
}
