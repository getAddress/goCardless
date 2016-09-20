using getAddress.GoCardless;
using getAddress.GoCardless.Api.Responses;
using Newtonsoft.Json;

internal class CreditorResponseSingle
{
    [JsonProperty("creditors")]
    public CreditorResponse Creditor { get; internal set; }

    private CreditorResponseSingle()
    {

    }

}
public class CreditorResponse : ResponseBase
{
    internal GoCardlessApi Api { get; set; }

    private CreditorResponse()
    {

    }

}