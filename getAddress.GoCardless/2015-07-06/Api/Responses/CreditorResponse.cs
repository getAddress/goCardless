using getAddress.GoCardless.Api.Responses;
using Newtonsoft.Json;

internal class CreditorResponseSingle
{
    [JsonProperty("creditors")]
    public CreditorResponse Creditor { get; internal set; }
}
public class CreditorResponse : ResponseBase
{

   

}