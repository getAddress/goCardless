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

        public async Task<CustomerBankAccountResponse> Get(ICustomerBankAccountId customerBankAccountId)
        {
            if (customerBankAccountId == null) throw new ArgumentNullException(nameof(customerBankAccountId));

            var json = await Api.Get(Path + customerBankAccountId.CustomerBankAccountId.Value);

            var single = Api.Deserialize<CustomerBankAccountsResponseSingle>(json);

            single.CustomerBankAccount.Api = Api;

            single.CustomerBankAccount.Raw = json;

            return single.CustomerBankAccount;
        }
    }
}
