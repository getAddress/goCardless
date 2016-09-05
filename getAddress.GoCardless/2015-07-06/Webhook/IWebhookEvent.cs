using System;

namespace getAddress.GoCardless._2015_07_06.Webhook
{
    public interface IWebhookEvent
    {
        DateTime CreatedAt { get; }
        string Id { get; }

    }
}