goCardless API for .net
========

Wrapper for:
https://developer.gocardless.com/api-reference/2015-07-06/#overview

## Install

```
Install from Nuget:

PM> Install-Package getAddress.goCardless
```

## Typical Usage

### Cancel a subscription 

```
using (var api = new GoCardlessApi("<your API Key>"))  /*Use ReadWrite key*/
{
  var subscription = await api.Subscriptions.Get(new SubscriptionId("<subcription id>"));

  if (subscription.Status == Status.active || subscription.Status == Status.pending_customer_approval)
  {
      await subscription.Cancel();
  }
}
```

### Update customer email address 
```
using (var api = new GoCardlessApi("<your API Key>"))  /*Use ReadWrite key*/
{
  var customer = await api.Customer.Get(new CustomerId("<customer id>"));

  customer.Email = "new@email.com";

  await customer.Update();
}
```

### Webhook - New subscription 
```
[HttpPost]
public async Task<IHttpActionResult> GoCardlessWebHook()
{
    try
    {
        var requestContent = await Request.Content.ReadAsStringAsync();
        var header = Request.Headers.GetValues("Webhook-Signature").FirstOrDefault();
        var secret = "<your secret>";

        if (!string.IsNullOrWhiteSpace(header) && !string.IsNullOrWhiteSpace(requestContent))
        {
            var events = GoCardlessWebhookHandler.GetSignedEvents(requestContent, header, secret);

            if (events.IsValid)
            {
                //see: https://developer.gocardless.com/2015-07-06/#webhooks-signing-webhooks
                if (events.Subscriptions.Created().Any())
                {
                    using (var api = new GoCardlessApi("<your API key>")
                    {
                        var subscriptions = events.Subscriptions.Created();

                        foreach (var subscription in subscriptions)
                        {
                            var subscriptionResponse = await api.Subscriptions.Get(subscription.SubscriptionId);

                            await CreateNewAccount(subscriptionResponse); //your code
                        }
                    }
                }
            }
            else
            {
               return new System.Web.Http.Results.StatusCodeResult((HttpStatusCode)498, this);
            }
        }

        return Ok();
    }
    catch (Exception ex)
    {
        await SendEmail(ex);
    }
    return BadRequest();
}
```


