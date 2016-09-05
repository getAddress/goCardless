
using getAddress.GoCardless._2015_07_06.Common.Ids;
using Newtonsoft.Json;

namespace getAddress.GoCardless._2015_07_06.Api.Responses
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
