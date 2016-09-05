using getAddress.GoCardless._2015_07_06.Common.Ids;

namespace getAddress.GoCardless._2015_07_06.Webhook
{
    public class SubscriptionCreatedWebhookEvent : SubscriptionWebhookEvent
    {
        internal SubscriptionCreatedWebhookEvent(WebhookEvent webhookEvent) : base(webhookEvent)
        {
            var subscriptionIdValue = webhookEvent.Links?.Subscription;

            SubscriptionId = new SubscriptionId(subscriptionIdValue);
        }

        public SubscriptionId SubscriptionId { get; set; }

    }
}
