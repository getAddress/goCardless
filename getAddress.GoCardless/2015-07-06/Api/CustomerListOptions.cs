
using getAddress.GoCardless.Common.Ids;

namespace getAddress.GoCardless.Api
{
    public class CustomerListOptions
    {

        public int Limit { get; set; }

        public CustomerId After { get; set; }

        public CustomerId Before { get; set; }
    }
}
