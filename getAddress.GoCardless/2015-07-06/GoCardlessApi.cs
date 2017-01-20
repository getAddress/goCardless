using getAddress.GoCardless.Api;
using Newtonsoft.Json;
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

        public GoCardlessApi(string accessToken):this(GetApiEnvironment(accessToken),new AccessToken(accessToken))
        {
           
        }

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
            Payments = new PaymentApi(this);

            client = new HttpClient { BaseAddress = this.Environment.Url };
            client.DefaultRequestHeaders.TryAddWithoutValidation("GoCardless-Version", Version);
            client.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken.Value);
        }

        internal HttpClient HttpClient
        {
            get { return client; }
        }

        private static APis.ApiEnvironment GetApiEnvironment(string accessToken)
        {
            if (accessToken.StartsWith("live_"))
            {
                return APis.ApiEnvironment.Live;
            }
            if (accessToken.StartsWith("sandbox_"))
            {
                return APis.ApiEnvironment.Sandbox;
            }
            else
            {
                throw  new ArgumentNullException(nameof(accessToken));
            }
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
        public PaymentApi Payments
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

        internal async Task<HttpResponseMessage> Post(string path, object entity = null)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            entity = entity ?? string.Empty;
            var jsonString = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(entity));
            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await client.PostAsync(path, httpContent);
        }

        internal async Task<HttpResponseMessage> Put(string path, object entity)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            var jsonString = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(entity));

            HttpContent httpContent = new StringContent(jsonString);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return await client.PutAsync(path, httpContent);
        }

        internal T Deserialize<T>(string json)
        {
            var settings = new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            };

            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}