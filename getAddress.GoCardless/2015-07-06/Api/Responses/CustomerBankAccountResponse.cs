
using getAddress.GoCardless.Common.Ids;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace getAddress.GoCardless.Api.Responses
{
    internal class CustomerBankAccountsResponseSingle
    {

        private CustomerBankAccountsResponseSingle()
        {

        }

        [JsonProperty("customer_bank_accounts")]
        public CustomerBankAccountResponse CustomerBankAccount { get; internal set; }
    }

    public class CustomerBankAccountResponse : ResponseBase, ICustomerId
    {
        public CustomerId CustomerId
        {
            get
            {
                return new CustomerId(Links?.Customer);
            }
        }

        internal GoCardlessApi Api { get; set; }

        private CustomerBankAccountResponse()
        {

        }

        public async Task<CustomerResponse> GetCustomer()
        {
            return await GetCustomer(this);
        }
        public static async Task<CustomerResponse> GetCustomer(CustomerBankAccountResponse customerBankAccountResponse)
        {
            if (customerBankAccountResponse == null) throw new ArgumentNullException(nameof(customerBankAccountResponse));

            return await customerBankAccountResponse.Api.Customer.Get(customerBankAccountResponse);
        }
    }
}
