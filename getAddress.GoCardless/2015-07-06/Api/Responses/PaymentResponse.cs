using getAddress.GoCardless.Common.Ids;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Threading.Tasks;

namespace getAddress.GoCardless.Api.Responses
{
    internal class PaymentResponseSingle
    {
        [JsonProperty("payments")]
        public PaymentResponse Payment { get; internal set; }

        private PaymentResponseSingle()
        {

        }
    }


    public class PaymentResponse : ResponseBase, ICreditorId,IMandateId,IPaymentId,ISubscriptionId
    {
        private PaymentResponse()
        {

        }

        [JsonIgnore]
        public PaymentId PaymentId { get { return new PaymentId(this.Id); } }

        internal GoCardlessApi Api { get; set; }

        [JsonProperty("charge_date")]
        public DateTime ChargeDate { get; internal set; }

        [JsonProperty("amount")]
        public decimal Amount { get; internal set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatus Status { get; internal set; }

        public SubscriptionId SubscriptionId
        {
            get
            {
                return new SubscriptionId(Links?.Subscription);
            }
        }

        public CreditorId CreditorId
        {
            get
            {
                return new CreditorId(Links?.Creditor);
            }
        }

        public MandateId MandateId
        {
            get
            {
                return new MandateId(Links?.Mandate);
            }
        }

        public async Task<CreditorResponse> GetCreditor()
        {
            return await GetCreditor(this);
        }
        public static async Task<CreditorResponse> GetCreditor(PaymentResponse paymentResponse)
        {
            return await paymentResponse.Api.Creditor.Get(paymentResponse);
        }

        public async Task<SubscriptionResponse> GetSubscription()
        {
            return await GetSubscription(this);
        }

        public static async Task<SubscriptionResponse> GetSubscription(PaymentResponse paymentResponse)
        {
            return await paymentResponse.Api.Subscriptions.Get(paymentResponse);
        }


        public async Task<MandateResponse> GetMandate()
        {
            return await GetMandate(this);
        }

        public static async Task<MandateResponse> GetMandate(PaymentResponse paymentResponse)
        {
            var mandate = await paymentResponse.Api.Mandates.Get(paymentResponse);

            return mandate;
        }

        public async Task<CustomerResponse> GetCustomer()
        {
            return await GetCustomer(this);
        }

        public static async Task<CustomerResponse> GetCustomer(PaymentResponse paymentResponse)
        {
            if (paymentResponse == null) throw new ArgumentNullException(nameof(paymentResponse));

            var customerBankAccount = await GetCustomerBankAccount(paymentResponse);

            var customer = await customerBankAccount.GetCustomer();

            return customer;
        }

        public async Task<CustomerBankAccountResponse> GetCustomerBankAccount()
        {
            return await GetCustomerBankAccount(this);
        }

        public static async Task<CustomerBankAccountResponse> GetCustomerBankAccount(PaymentResponse paymentResponse)
        {
            var mandate = await GetMandate(paymentResponse);

            return await mandate.GetCustomerBankAccount();
        }

    }


}
