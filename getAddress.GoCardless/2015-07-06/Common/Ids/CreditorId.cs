
using System;

namespace getAddress.GoCardless.Common.Ids
{
    public interface ICreditorId
    {
        CreditorId CreditorId { get;  }
    }
    public class CreditorId : ValueBase,ICreditorId
    {
        public CreditorId(string value) : base(value)
        {

        }

        CreditorId ICreditorId.CreditorId
        {
            get
            {
                return this;
            }
        }
    }
}
