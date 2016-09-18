

using System;

namespace getAddress.GoCardless.Common.Ids
{

    public interface ISubscriptionId
    {
        SubscriptionId SubscriptionId { get; }
    }

    public class SubscriptionId : ValueBase, ISubscriptionId
    {
        public SubscriptionId(string value) : base(value)
        {

        }

        SubscriptionId ISubscriptionId.SubscriptionId
        {
            get
            {
                return this;
            }
        }
    }
}
