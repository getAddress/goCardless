using getAddress.GoCardless.Common.Ids;
using Newtonsoft.Json;

namespace getAddress.GoCardless.Api.Responses
{
    internal class MandateResponseSingle
    {
        [JsonProperty("mandates")]
        public MandateResponse Mandate { get; internal set; }
    }
    public class MandateResponse : ResponseBase
    {

        public CustomerBankAccountId CustomerBankAccountId
        {
            get
            {
                return new CustomerBankAccountId(Links?.CustomerBankAccount);
            }
        }

    }
}
