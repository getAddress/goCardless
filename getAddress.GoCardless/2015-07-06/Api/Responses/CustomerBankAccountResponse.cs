
using getAddress.GoCardless.Common.Ids;
using Newtonsoft.Json;

namespace getAddress.GoCardless.Api.Responses
{
    internal class CustomerBankAccountsResponseSingle
    {
        [JsonProperty("customer_bank_accounts")]
        public CustomerBankAccountResponse CustomerBankAccount { get; internal set; }
    }

    public class CustomerBankAccountResponse : ResponseBase
    {
        public CustomerId CustomerId
        {
            get
            {
                return new CustomerId(Links?.Customer);
            }
        }
    }
}
