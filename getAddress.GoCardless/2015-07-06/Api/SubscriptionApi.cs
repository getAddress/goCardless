using getAddress.GoCardless._2015_07_06.Api.Responses;
using getAddress.GoCardless._2015_07_06.Common.Ids;
using System.Threading.Tasks;

namespace getAddress.GoCardless._2015_07_06.Api
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
