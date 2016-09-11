using getAddress.GoCardless.Api.Responses;
using getAddress.GoCardless.Common.Ids;
using System.Threading.Tasks;

namespace getAddress.GoCardless.Api
{
    public class SubscriptionApi : ApiBase
    {

        private const string Path = "subscriptions/";

        internal SubscriptionApi(GoCardlessApi api) : base(api)
        {

        }

        public async Task<SubscriptionResponse> Get(SubscriptionId subscriptionId)
        {
            var json = await Api.Get(Path + subscriptionId.Value);

            var single = Api.Deserialize<SubscriptionResponseSingle>(json);

            return single.Subscription;
        }
    }
}
