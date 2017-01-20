
using System.Collections.Generic;
using System.Linq;


namespace getAddress.GoCardless.Webhook
{
    public class Payments
    {
        private readonly WebhookEventCollection WebhookEventCollection;

        internal Payments(WebhookEventCollection webhookEventCollection)
        {
            WebhookEventCollection = webhookEventCollection;
        }

        public IEnumerable<PaymentPaidOutWebhookEvent> PaidOut()
        {
            return WebhookEventCollection.AllWebhooks.Where(s => s.ResourceType == ResourceType.payments)
                .Where(s => s.ActionType == Action.paid_out).Select(s => new PaymentPaidOutWebhookEvent(s));
        }
    }
}
