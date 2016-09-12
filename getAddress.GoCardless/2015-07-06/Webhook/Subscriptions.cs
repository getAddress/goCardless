
using System.Collections.Generic;
using System.Linq;


namespace getAddress.GoCardless.Webhook
{
    public class Subscriptions
    {
        private readonly WebhookEventCollection WebhookEventCollection;

        internal Subscriptions(WebhookEventCollection webhookEventCollection)
        {
            WebhookEventCollection = webhookEventCollection;
        }

        public IEnumerable<SubscriptionCreatedWebhookEvent> Created()
        {
            return WebhookEventCollection.AllWebhooks.Where(s => s.ResourceType == ResourceType.subscriptions).Where(s => s.ActionType == Action.created).Select(s => new SubscriptionCreatedWebhookEvent(s));
        }
    }

    
}
