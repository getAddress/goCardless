using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace getAddress.GoCardless._2015_07_06.Webhook
{
   
    internal class WebhookEvent : IWebhookEvent 
    {
        internal WebhookEvent()
        {

        }


        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; internal set; }

        [JsonProperty("resource_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        internal ResourceType ResourceType { get;  set; }

        [JsonProperty("action")]
        internal string Action { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        internal Action ActionType {
            get
            {
                Action action;
                if (Enum.TryParse(this.Action, out action))
                {
                    return action;
                }

                return Webhook.Action.unknown;
            }
        }
    }
   

}