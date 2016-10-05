
namespace getAddress.GoCardless.Api.Responses
{
    public enum Interval
    {
        weekly,
        monthly,
        yearly
    }

    public enum Status
    {
        pending_customer_approval,
        customer_approval_denied,
        active,
        finished,
        cancelled
    }
}
