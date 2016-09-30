using getAddress.GoCardless.Common.Ids;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Threading.Tasks;

namespace getAddress.GoCardless.Api.Responses
{

    internal class SubscriptionResponseSingle
    {
        [JsonProperty("subscriptions")]
        public SubscriptionResponse Subscription { get; internal set; }

        private SubscriptionResponseSingle()
        {

        }
    }

    public class SubscriptionResponse : ResponseBase, IMandateId, ISubscriptionId
    {

        private SubscriptionResponse()
        {

        }

        internal GoCardlessApi Api { get; set; }

        [JsonIgnore]
        public SubscriptionId SubscriptionId { get { return new SubscriptionId(this.Id); } }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("amount")]
        public decimal Amount { get; internal set; }

        [JsonProperty("interval_unit")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Interval Interval { get; internal set; }

        public MandateId MandateId
        {
            get
            {
                return new MandateId(Links?.Mandate);
            }
        }

        public  async Task<CustomerResponse> GetCustomer()
        {
            return await GetCustomer(this);
        }

        public static async Task<CustomerResponse> GetCustomer(SubscriptionResponse subscriptionResponse)
        {
            if (subscriptionResponse == null) throw new ArgumentNullException(nameof(subscriptionResponse));

            var customerBankAccount = await GetCustomerBankAccount(subscriptionResponse);

            var customer = await customerBankAccount.GetCustomer();

            return customer;
        }

        public async Task<MandateResponse> GetMandate()
        {
            return await GetMandate(this);
        }

        public static async Task<MandateResponse> GetMandate(SubscriptionResponse subscriptionResponse)
        {
            var mandate = await subscriptionResponse.Api.Mandates.Get(subscriptionResponse);

            return mandate;
        }

        public async Task<CustomerBankAccountResponse> GetCustomerBankAccount()
        {
            return await GetCustomerBankAccount(this);
        }

        public static async Task<CustomerBankAccountResponse> GetCustomerBankAccount(SubscriptionResponse subscriptionResponse)
        {
            var mandate = await GetMandate(subscriptionResponse);

            return await mandate.GetCustomerBankAccount();
        }


        public  async Task<CreditorResponse> GetCreditor()
        {
            return await GetCreditor(this);
        }
        public static async Task<CreditorResponse> GetCreditor(SubscriptionResponse subscriptionResponse)
        {
            var mandate = await GetMandate(subscriptionResponse);

            return await mandate.GetCreditor();
        }

        public async Task Cancel()
        {
            await Cancel(Api, this);
        }

        public static async Task Cancel(GoCardlessApi api, ISubscriptionId subscriptionId)
        {
           await api.Subscriptions.Cancel(subscriptionId);
        }

    }

}
