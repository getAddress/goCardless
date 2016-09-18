using getAddress.GoCardless.Api;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace getAddress.GoCardless
{

    public class GoCardlessApi:IDisposable
    {
        const string Version = "2015-07-06";
        private readonly AccessToken AccessToken;
        private readonly HttpClient client;

        public GoCardlessApi(APis.ApiEnvironment environment, AccessToken accessToken)
        {
            if (environment == null) throw new ArgumentNullException(nameof(environment));
            if (accessToken == null) throw new ArgumentNullException(nameof(accessToken)); 

            Environment = environment;
            AccessToken = accessToken;

            Subscriptions = new SubscriptionApi(this);
            Mandates = new MandateApi(this);
            CustomerBankAccount = new CustomerBankAccountApi(this);
            Customer = new CustomerApi(this);
            Creditor  = new CreditorApi(this);

            client = new HttpClient { BaseAddress = this.Environment.Url };
            client.DefaultRequestHeaders.TryAddWithoutValidation("GoCardless-Version", Version);
            client.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken.Value);
        }

        public APis.ApiEnvironment Environment
        {
            get;
        }

        public SubscriptionApi Subscriptions
        {
            get;
        }

        public MandateApi Mandates
        {
            get;
        }

        public CustomerBankAccountApi CustomerBankAccount
        {
            get;
        }

        public CustomerApi Customer
        {
            get;
        }

        public CreditorApi Creditor
        {
            get;
        }


        internal async Task<string> Get(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path)); 
            return await client.GetStringAsync(path);
        }

        internal T Deserialize<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}