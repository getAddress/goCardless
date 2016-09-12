using System;


namespace getAddress.GoCardless.Webhook
{
    public abstract class PayoutWebhookEvent : IWebhookEvent
    {
        internal PayoutWebhookEvent(WebhookEvent webhookEvent)
        {
            if (webhookEvent == null) throw new ArgumentNullException(nameof(webhookEvent));

            if (webhookEvent.ResourceType == ResourceType.payouts)
            {
                this.Id = webhookEvent.Id;
                this.CreatedAt = webhookEvent.CreatedAt;
            }
        }

        public string Id { get; }

        public DateTime CreatedAt { get; }

    }
}
