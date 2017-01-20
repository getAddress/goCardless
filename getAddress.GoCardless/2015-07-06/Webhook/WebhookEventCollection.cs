using System.Collections.Generic;
using System.Linq;


namespace getAddress.GoCardless.Webhook
{
    public class WebhookEventCollection
    {
        private readonly List<WebhookEvent> list = new List<WebhookEvent>();

        internal WebhookEventCollection(IEnumerable<WebhookEvent> webhooks, bool isValid)
        {
            IsValid = isValid;
            
            if(webhooks != null && IsValid) AddRange(webhooks);

            Subscriptions = new Subscriptions(this);
            Payouts = new Payouts(this);
            Payments = new Payments(this);
        }

        internal IEnumerable<WebhookEvent> AllWebhooks
        { get {

                return list.AsEnumerable();
         } }

        public bool IsValid { get; }

        public Subscriptions Subscriptions
        {
            get;
        }

        public Payouts Payouts
        {
            get;
        }

        public Payments Payments
        {
            get;
        }

        internal void Add(WebhookEvent webhook)
        {
            list.Add(webhook);
        }

        internal void AddRange(IEnumerable<WebhookEvent> webhooks)
        {
            list.AddRange(webhooks);
        }



    }
}