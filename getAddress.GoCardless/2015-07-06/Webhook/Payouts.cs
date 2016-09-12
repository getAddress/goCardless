
using System.Collections.Generic;
using System.Linq;


namespace getAddress.GoCardless.Webhook
{
    public class Payouts
    {
        private readonly WebhookEventCollection WebhookEventCollection;

        internal Payouts(WebhookEventCollection webhookEventCollection)
        {
            WebhookEventCollection = webhookEventCollection;
        }

        public IEnumerable<PayoutPaidWebhookEvent> Paid()
        {
            return WebhookEventCollection.AllWebhooks.Where(s => s.ResourceType == ResourceType.payouts)
                .Where(s => s.ActionType == Action.paid).Select(s => new PayoutPaidWebhookEvent(s));
        }
    }
}
