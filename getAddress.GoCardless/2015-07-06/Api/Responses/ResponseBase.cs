using getAddress.GoCardless.Webhook;
using Newtonsoft.Json;
using System;

namespace getAddress.GoCardless.Api.Responses
{
    public abstract class ResponseBase
    {
        
        [JsonProperty("id")]
        internal string Id { get;  set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; internal set; }

        [JsonProperty("links")]
        internal Links Links { get; set; }

        public string Raw { get; set; }

        public bool ShouldSerializeId()
        {
            return false;
        }
        public bool ShouldSerializeLinks()
        {
            return false;
        }
        public bool ShouldSerializeCreatedAt()
        {
            return false;
        }
    }
}
