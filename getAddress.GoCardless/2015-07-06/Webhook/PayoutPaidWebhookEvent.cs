using getAddress.GoCardless.Common.Ids;


namespace getAddress.GoCardless.Webhook
{
    public class PayoutPaidWebhookEvent : PayoutWebhookEvent
    {
        internal PayoutPaidWebhookEvent(WebhookEvent webhookEvent) : base(webhookEvent)
        {
            var payoutIdValue = webhookEvent.Links?.Payout;

            PayoutId = new PayoutId(payoutIdValue);
        }

        public PayoutId PayoutId { get; set; }

    }
}
