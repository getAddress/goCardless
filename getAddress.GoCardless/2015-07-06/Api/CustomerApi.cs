using getAddress.GoCardless.Api.Responses;
using getAddress.GoCardless.Common.Ids;
using System;
using System.Threading.Tasks;

namespace getAddress.GoCardless.Api
{
    public class CustomerApi : ApiBase
    {

        private const string Path = "customers/";

        internal CustomerApi(GoCardlessApi api) : base(api)
        {

        }

        public async Task<CustomerResponse> Get(ICustomerId customerId)
        {
            if (customerId == null) throw new ArgumentNullException(nameof(customerId));

            var json = await Api.Get(Path + customerId.CustomerId.Value);

            var single = Api.Deserialize<CustomerResponseSingle>(json);

            return single.Customer;
        }
    }
}
