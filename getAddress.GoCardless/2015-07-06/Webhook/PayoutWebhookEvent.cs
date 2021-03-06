﻿using getAddress.GoCardless.Common.Ids;
using System;


namespace getAddress.GoCardless.Webhook
{
    public abstract class PayoutWebhookEvent : IWebhookEvent,IPayoutId
    {
        internal PayoutWebhookEvent(WebhookEvent webhookEvent)
        {
            if (webhookEvent == null) throw new ArgumentNullException(nameof(webhookEvent));

            if (webhookEvent.ResourceType == ResourceType.payouts)
            {
                this.Id = webhookEvent.Id;
                this.CreatedAt = webhookEvent.CreatedAt;
            }

            var payoutIdValue = webhookEvent.Links?.Payout;

            PayoutId = new PayoutId(payoutIdValue);
        }

        public string Id { get; }

        public DateTime CreatedAt { get; }

        public PayoutId PayoutId { get; set; }
    }
}
