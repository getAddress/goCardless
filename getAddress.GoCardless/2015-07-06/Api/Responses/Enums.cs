
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

    public enum PaymentStatus
    {
        pending_customer_approval,
        pending_submission,
        submitted,
        confirmed,
        paid_out,
        cancelled,
        customer_approval_denied,
        failed,
        charged_back
    }
}
