using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Localization;

namespace blog__dotnet_azure_functions_localization;

public class GetResource
{
    private readonly IStringLocalizer _stringLocalizer;

    public GetResource(IStringLocalizer stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
    }

    [Function(nameof(GetResource))]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        var text = _stringLocalizer["Hello"];
        response.WriteString(text);

        return response;
    }
}
