
namespace getAddress.GoCardless.Common.Ids
{

    public interface IPayoutId
    {
        PayoutId PayoutId { get; }
    }
    public class PayoutId : ValueBase, IPayoutId
    {
        public PayoutId(string value) : base(value)
        {

        }

        PayoutId IPayoutId.PayoutId
        {
            get
            {
                return this;
            }
        }
    }
}
