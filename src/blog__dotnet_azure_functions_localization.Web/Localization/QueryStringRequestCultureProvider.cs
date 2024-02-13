using Microsoft.Azure.Functions.Worker.Http;

namespace blog__dotnet_azure_functions_localization;

public class QueryStringRequestCultureProvider : IRequestCultureProvider
{
    public string? GetCulture(HttpRequestData requestData)
    {
        return requestData.Query["culture"];
    }
}
