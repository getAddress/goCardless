using getAddress.GoCardless._2015_07_06.Api.Responses;
using getAddress.GoCardless._2015_07_06.Common.Ids;
using System;
using System.Threading.Tasks;

namespace getAddress.GoCardless._2015_07_06.Api
{
    public class CustomerApi : ApiBase
    {

        private const string Path = "customers/";

        internal CustomerApi(GoCardlessApi api) : base(api)
        {

        }

        public async Task<CustomerResponse> Get(CustomerId customerId)
        {
            if (customerId == null) throw new ArgumentNullException(nameof(customerId));

            var json = await Api.Get(Path + customerId.Value);

            var single = Api.Deserialize<CustomerResponseSingle>(json);

            return single.Customer;
        }
    }
}
