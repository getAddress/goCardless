using getAddress.GoCardless.Webhook;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

namespace getAddress.GoCardless
{

    public static class GoCardlessWebhookHandler
    {

        private class WebhookEvents
        {
            [JsonProperty("events")]
            public WebhookEvent[] Events { get; set; }
        }

        public static WebhookEventCollection GetEvents(string json)
        {
            if (json == null) throw new ArgumentNullException(nameof(json));
            
            var webhookEvents = JsonConvert.DeserializeObject<WebhookEvents>(json);

            return new WebhookEventCollection(webhookEvents.Events, true);
          
        }

        public static WebhookEventCollection GetSignedEvents(string json, string signature, string secret)
        {
            if (json == null) throw new ArgumentNullException(nameof(json));
            if (signature == null) throw new ArgumentNullException(nameof(signature));
            if (secret == null) throw new ArgumentNullException(nameof(secret));

            var hashedJson = HashJson(json, secret);

            var isValid = hashedJson == signature;

            if (isValid)
            {
                return GetEvents(json);
            }

            throw new ArgumentException("Invalid signature");
        }

        public static string HashJson(string json, string secret)
        {
            if (json == null) throw new ArgumentNullException(nameof(json));
            if (secret == null) throw new ArgumentNullException(nameof(secret));

            var encoding = new UTF8Encoding();
            var jsonBytes = encoding.GetBytes(json);
            var secretBytes = encoding.GetBytes(secret);

            using (var hmacsha256 = new HMACSHA256(secretBytes))
            {
                var computedHash = hmacsha256.ComputeHash(jsonBytes);

                return HexStringFromBytes(computedHash);
            }

        }

        public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

        private static bool AreEqual(byte[] hash1, byte[] hash2)
        {
            var areEqual = false;
            if (hash1.Length == hash2.Length)
            {
                int i = 0;
                while ((i < hash1.Length) && (hash1[i] == hash2[i]))
                {
                    i += 1;
                }
                if (i == hash1.Length)
                {
                    areEqual = true;
                }
            }

            return areEqual;
        }

    }
}