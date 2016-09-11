using getAddress.GoCardless.Api.Responses;
using getAddress.GoCardless.Common.Ids;
using System;
using System.Threading.Tasks;

namespace getAddress.GoCardless.Api
{
    public class CustomerBankAccountApi : ApiBase
    {

        private const string Path = "customer_bank_accounts/";

        internal CustomerBankAccountApi(GoCardlessApi api) : base(api)
        {

        }

        public async Task<CustomerBankAccountResponse> Get(CustomerBankAccountId customerBankAccountId)
        {
            if (customerBankAccountId == null) throw new ArgumentNullException(nameof(customerBankAccountId));

            var json = await Api.Get(Path + customerBankAccountId.Value);

            var single = Api.Deserialize<CustomerBankAccountsResponseSingle>(json);

            return single.CustomerBankAccount;
        }
    }
}
