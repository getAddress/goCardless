
namespace getAddress.GoCardless.Common.Ids
{

    public interface IPaymentId
    {
        PaymentId PaymentId { get; }
    }
    public class PaymentId : ValueBase, IPaymentId
    {
        public PaymentId(string value) : base(value)
        {

        }

        PaymentId IPaymentId.PaymentId
        {
            get
            {
                return this;
            }
        }
    }
}
