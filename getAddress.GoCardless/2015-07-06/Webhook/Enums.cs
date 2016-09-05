
namespace getAddress.GoCardless._2015_07_06.Webhook
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
