using getAddress.GoCardless._2015_07_06.Common.Ids;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace getAddress.GoCardless._2015_07_06.Api.Responses
{

    internal class SubscriptionResponseSingle
    {
        [JsonProperty("subscriptions")]
        public SubscriptionResponse Subscription { get; internal set; }
    }

    public class SubscriptionResponse: ResponseBase
    {


        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("amount")]
        public decimal Amount { get; internal set; }

        [JsonProperty("interval_unit")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Interval Interval { get; internal set; }

        public MandateId MandateId {
            get{
                return new MandateId(Links?.Mandate);
            }
         }

    }

}
