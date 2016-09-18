
namespace getAddress.GoCardless.Common.Ids
{
    public interface IMandateId
    {
        MandateId MandateId { get; }
    }
    public class MandateId : ValueBase, IMandateId
    {
        public MandateId(string value) : base(value)
        {

        }

        MandateId IMandateId.MandateId
        {
            get
            {
                return this;
            }
        }
    }
}
