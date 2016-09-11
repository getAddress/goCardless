using System;

namespace getAddress.GoCardless.Webhook
{
    public interface IWebhookEvent
    {
        DateTime CreatedAt { get; }
        string Id { get; }

    }
}