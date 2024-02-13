using System.Globalization;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Localization;

namespace blog__dotnet_azure_functions_localization;

public class GetCulture
{
    private readonly IStringLocalizer _stringLocalizer;

    public GetCulture(IStringLocalizer stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
    }

    [Function(nameof(GetCulture))]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        var currentCulture = CultureInfo.CurrentUICulture.Name;
        response.WriteString(currentCulture);

        return response;
    }
}
