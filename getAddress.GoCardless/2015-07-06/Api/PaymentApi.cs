using getAddress.GoCardless.Api.Responses;
using getAddress.GoCardless.Common.Ids;
using System.Threading.Tasks;

namespace getAddress.GoCardless.Api
{
    public class PaymentApi: ApiBase
    {

        private const string Path = "payments/";

        internal PaymentApi(GoCardlessApi api) : base(api)
        {

        }

        public async Task<PaymentResponse> Get(IPaymentId paymentId)
        {
            var json = await Api.Get(Path + paymentId.PaymentId.Value);

            var single = Api.Deserialize<PaymentResponseSingle>(json);

            single.Payment.Api = Api;
            single.Payment.Raw = json;

            return single.Payment;
        }

    }
}
