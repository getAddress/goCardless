using getAddress.GoCardless.Common.Ids;
using System;
using System.Threading.Tasks;

namespace getAddress.GoCardless.Api
{
    public class CreditorApi : ApiBase
    {

        private const string Path = "creditors/";

        internal CreditorApi(GoCardlessApi api) : base(api)
        {

        }

        public async Task<CreditorResponse> Get(ICreditorId creditorId)
        {
            if (creditorId == null) throw new ArgumentNullException(nameof(creditorId));

            var json = await Api.Get(Path + creditorId.CreditorId.Value);

            var single = Api.Deserialize<CreditorResponseSingle>(json);

            single.Creditor.Api = Api;

            single.Creditor.Raw = json;

            return single.Creditor;
        }
    }
}
