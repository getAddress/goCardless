using getAddress.GoCardless.Api.Responses;
using getAddress.GoCardless.Common.Ids;
using System.Threading.Tasks;

namespace getAddress.GoCardless.Api
{
    public class MandateApi : ApiBase
    {

        private const string Path = "mandates/";

        internal MandateApi(GoCardlessApi api) : base(api)
        {

        }
        public async Task<MandateResponse> Get(IMandateId mandateId)
        {
            var json = await Api.Get(Path + mandateId.MandateId.Value);

            var single = Api.Deserialize<MandateResponseSingle>(json);

            single.Mandate.Api = Api;

            single.Mandate.Raw = json;

            return single.Mandate;
        }
    }
}
