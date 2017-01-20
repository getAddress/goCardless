using getAddress.GoCardless.Common.Ids;


namespace getAddress.GoCardless.Webhook
{
    public class PaymentPaidOutWebhookEvent : PaymentWebhookEvent
    {
        internal PaymentPaidOutWebhookEvent(WebhookEvent webhookEvent) : base(webhookEvent)
        {
        
        }

    }
}
