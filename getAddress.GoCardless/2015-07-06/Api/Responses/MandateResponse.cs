using getAddress.GoCardless.Common.Ids;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace getAddress.GoCardless.Api.Responses
{
    internal class MandateResponseSingle
    {
        [JsonProperty("mandates")]
        public MandateResponse Mandate { get; internal set; }

        private MandateResponseSingle()
        {

        }
    }
    public class MandateResponse : ResponseBase, ICreditorId, ICustomerBankAccountId
    {
        private MandateResponse()
        {

        }

        internal GoCardlessApi Api { get; set; }

        public CustomerBankAccountId CustomerBankAccountId
        {
            get
            {
                return new CustomerBankAccountId(Links?.CustomerBankAccount);
            }
        }

        public CreditorId CreditorId
        {
            get
            {
                return new CreditorId(Links?.Creditor);
            }
        }

        public async Task<CustomerBankAccountResponse> GetCustomerBankAccount()
        {
            return await GetCustomerBankAccount(this);
        }

        public static async Task<CustomerBankAccountResponse> GetCustomerBankAccount(MandateResponse mandateResponse)
        {
           return  await mandateResponse.Api.CustomerBankAccount.Get(mandateResponse);
        }


        public  async Task<CreditorResponse> GetCreditor()
        {
            return await GetCreditor(this);
        }
        public static async Task<CreditorResponse> GetCreditor(MandateResponse mandateResponse)
        {
            return await mandateResponse.Api.Creditor.Get(mandateResponse);
        }
    }
}
