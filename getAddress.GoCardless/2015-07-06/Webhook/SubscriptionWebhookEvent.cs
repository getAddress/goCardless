using getAddress.GoCardless.Common.Ids;
using System;

namespace getAddress.GoCardless.Webhook
{
    public abstract class SubscriptionWebhookEvent : IWebhookEvent,ISubscriptionId
    {
        internal SubscriptionWebhookEvent(WebhookEvent webhookEvent)
        {
            if (webhookEvent == null) throw new ArgumentNullException(nameof(webhookEvent));

            if (webhookEvent.ResourceType == ResourceType.subscriptions)
            {
                this.Id = webhookEvent.Id;
                this.CreatedAt = webhookEvent.CreatedAt;
            }
            var subscriptionIdValue = webhookEvent.Links?.Subscription;

            SubscriptionId = new SubscriptionId(subscriptionIdValue);
        }

        public string Id { get; }

        public DateTime CreatedAt { get; }

        public SubscriptionId SubscriptionId { get; set; }


    }
}
