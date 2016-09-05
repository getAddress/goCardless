using getAddress.GoCardless._2015_07_06.Webhook;
using Newtonsoft.Json;

namespace getAddress.GoCardless._2015_07_06.Api.Responses
{
    public abstract class ResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("links")]
        internal Links Links { get; set; }
    }
}
