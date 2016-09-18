using Newtonsoft.Json;

namespace getAddress.GoCardless.Webhook
{
    [JsonObject("links")]
    public class Links
    {
        [JsonProperty("subscription")]
        public string Subscription { get; internal set; }

        [JsonProperty("payment")]
        public string Payment { get; internal set; }

        [JsonProperty("payout")]
        public string Payout { get; internal set; }

        [JsonProperty("mandate")]
        public string Mandate { get; internal set; }

        [JsonProperty("customer_bank_account")]
        public string CustomerBankAccount { get; internal set; }

        [JsonProperty("customer")]
        public string Customer { get; internal set; }


        [JsonProperty("creditor")]
        public string Creditor { get; internal set; }
        


    }

}
