using getAddress.GoCardless.Common.Ids;
using System;


namespace getAddress.GoCardless.Webhook
{
    public abstract class PaymentWebhookEvent : IWebhookEvent, IPaymentId
    {
        internal PaymentWebhookEvent(WebhookEvent webhookEvent)
        {
            if (webhookEvent == null) throw new ArgumentNullException(nameof(webhookEvent));

            if (webhookEvent.ResourceType == ResourceType.payments)
            {
                this.Id = webhookEvent.Id;
                this.CreatedAt = webhookEvent.CreatedAt;

                var paymentIdValue = webhookEvent.Links?.Payment;

                PaymentId = new PaymentId(paymentIdValue);
            }
        }

        public string Id { get; }

        public DateTime CreatedAt { get; }

        public PaymentId PaymentId { get; set; }

    }
}
