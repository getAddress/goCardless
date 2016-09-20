using getAddress.GoCardless.Api.Responses;
using getAddress.GoCardless.Common.Ids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace getAddress.GoCardless.Api
{
    public class CustomerApi : ApiBase
    {

        private const string Path = "customers";

        internal CustomerApi(GoCardlessApi api) : base(api)
        {

        }

        public async Task<CustomerResponse> Get(ICustomerId customerId)
        {
            return await Get(Api, customerId);
        }

        public static async Task<CustomerResponse> Get(GoCardlessApi api, ICustomerId customerId)
        {
            if (api == null) throw new ArgumentNullException(nameof(api)); 
            if (customerId == null) throw new ArgumentNullException(nameof(customerId));

            var json = await api.Get(Path + '/' + customerId.CustomerId.Value);

            var single = api.Deserialize<CustomerResponseSingle>(json);

            single.Customer.Api = api;

            return single.Customer;
        }

        public async Task<IEnumerable<CustomerResponse>> List()
        {
            return await List(Api);
        }

        public static async Task<IEnumerable<CustomerResponse>> List(GoCardlessApi api)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

           
            var query = HttpUtility.ParseQueryString(string.Empty);
            //test code
            query["limit"] = 200.ToString();
            query["after"] = "CU00033MGFS5GT";
            //test code
           
            var json = await api.Get(Path + '?' + query.ToString());

            var multiple = api.Deserialize<CustomerResponseMultiple>(json);

            foreach (var customer in multiple.Customers)
            {
                customer.Api = api;
            }

            return multiple.Customers;
        }

        }
}
