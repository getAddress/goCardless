using getAddress.GoCardless.Common.Ids;

namespace getAddress.GoCardless.Webhook
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
