
namespace getAddress.GoCardless.Webhook
{
    //these are the objects status
    internal enum Action 
    {
        unknown,
        created,
        customer_approval_granted,
        customer_approval_denied,
        payment_created,
        cancelled,
        finished,
        paid,
        paid_out
    }

    internal enum ResourceType
    {
        payments,
        mandates,
        payouts,
        subscriptions

    }
}
