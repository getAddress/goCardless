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

        public async Task<SubscriptionResponse> Get(ISubscriptionId subscriptionId)
        {
            return await Get(Api, subscriptionId);
        }

        public static async Task<SubscriptionResponse> Get(GoCardlessApi api, ISubscriptionId subscriptionId)
        {
            var json = await api.Get(Path + subscriptionId.SubscriptionId.Value);

            var single = api.Deserialize<SubscriptionResponseSingle>(json);

            single.Subscription.Api = api;

            single.Subscription.Raw = json;

            return single.Subscription;
        }

        public async Task Cancel(ISubscriptionId subscriptionId)
        {
            await Cancel(Api, subscriptionId);
        }

        public static  async Task Cancel(GoCardlessApi api, ISubscriptionId subscriptionId)
        {
          var result =  await api.Post(Path + subscriptionId.SubscriptionId.Value + "/actions/cancel");

            if (!result.IsSuccessStatusCode)
            {
                throw new System.Exception(result.ReasonPhrase);
            }
        }
    }
}
