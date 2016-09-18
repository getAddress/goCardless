using System;

namespace getAddress.GoCardless.Common.Ids
{
    public interface ICustomerBankAccountId
    {
        CustomerBankAccountId CustomerBankAccountId { get; }
    }

    public class CustomerBankAccountId : ValueBase, ICustomerBankAccountId
    {
        public CustomerBankAccountId(string value) : base(value)
        {

        }

        CustomerBankAccountId ICustomerBankAccountId.CustomerBankAccountId
        {
            get
            {
                return this;
            }
        }
    }
}
