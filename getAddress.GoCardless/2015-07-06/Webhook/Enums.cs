
namespace getAddress.GoCardless.Webhook
{
    internal enum Action 
    {
        unknown,
        created,
        customer_approval_granted,
        customer_approval_denied,
        payment_created,
        cancelled,
        finished,

    }

    internal enum ResourceType
    {
        payments,
        mandates,
        payouts,
        subscriptions

    }
}
