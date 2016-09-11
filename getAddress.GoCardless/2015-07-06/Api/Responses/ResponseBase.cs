using getAddress.GoCardless.Webhook;
using Newtonsoft.Json;

namespace getAddress.GoCardless.Api.Responses
{
    public abstract class ResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("links")]
        internal Links Links { get; set; }
    }
}
