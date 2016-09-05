using System;

namespace getAddress.GoCardless._2015_07_06.Webhook
{
    public abstract class SubscriptionWebhookEvent : IWebhookEvent
    {
        internal SubscriptionWebhookEvent(WebhookEvent webhookEvent)
        {
            if (webhookEvent == null) throw new ArgumentNullException(nameof(webhookEvent));

            if (webhookEvent.ResourceType == ResourceType.subscriptions)
            {
                this.Id = webhookEvent.Id;
                this.CreatedAt = webhookEvent.CreatedAt;

            }
        }

        public string Id { get; }

        public DateTime CreatedAt { get; }

    }
}
