using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getAddress.GoCardless.APis
{
    public class ApiEnvironment
    {
        public Uri Url { get; }

        private ApiEnvironment(string url)
        {
            Url = new Uri(url);
        }

        public static ApiEnvironment Live
        {
            get
            {
                return new ApiEnvironment("https://api.gocardless.com/");
            }
        }

        public static ApiEnvironment Sandbox
        {
            get
            {
                return new ApiEnvironment("https://api-sandbox.gocardless.com/");
            }
        }
    }
}
