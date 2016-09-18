
using System;

namespace getAddress.GoCardless.Common.Ids
{
    public interface ICustomerId
    {
        CustomerId CustomerId { get; }
    }
    public class CustomerId : ValueBase, ICustomerId
    {
        public CustomerId(string value) : base(value)
        {

        }

        CustomerId ICustomerId.CustomerId
        {
            get
            {
                return this;
            }
        }
    }
}
