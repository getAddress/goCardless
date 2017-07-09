
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

            single.Customer.Raw = json;

            return single.Customer;
        }

        public async Task Update(CustomerResponse customer)
        {
             await Update(Api, customer);
        }
        public static async Task Update(GoCardlessApi api, CustomerResponse customer)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (customer.CustomerId == null) throw new ArgumentNullException(nameof(customer.CustomerId));

            var singleCustomer = new CustomerResponseSingle { Customer = customer };

            var newPath = Path + '/' + customer.CustomerId.Value;

            var response = await api.Put(newPath, singleCustomer);

            if (response.IsSuccessStatusCode)
            {
                customer.ResetOriginalProperties();
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
            
        }

        public async Task<IEnumerable<CustomerResponse>> List(CustomerListOptions options = null)
        {
            return await List(Api, options);
        }

        public static async Task<IEnumerable<CustomerResponse>> List(GoCardlessApi api, CustomerListOptions options = null)
        {
            if (api == null) throw new ArgumentNullException(nameof(api));

            var newPath = Path;

            if (options != null)//todo: move out
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                
                if(options.Limit > 0) query["limit"] = options.Limit.ToString();
                if(options.After != null) query["after"] = options.After.Value;
                if (options.Before != null) query["before"] = options.Before.Value;
               
                newPath = newPath + '?' + query.ToString();
            }

            var json = await api.Get(newPath);

            var multiple = api.Deserialize<CustomerResponseMultiple>(json);

            foreach (var customer in multiple.Customers)
            {
                customer.Api = api;
            }

            return multiple.Customers;
        }



 }


}
