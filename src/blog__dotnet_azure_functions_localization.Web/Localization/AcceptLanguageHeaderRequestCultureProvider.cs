using Microsoft.Azure.Functions.Worker.Http;

namespace blog__dotnet_azure_functions_localization;

public class AcceptLanguageHeaderRequestCultureProvider : IRequestCultureProvider
{
    public string? GetCulture(HttpRequestData request)
    {
        request.Headers.TryGetValues("Accept-Language", out IEnumerable<string>? acceptLanguageHeaderValues);

        return acceptLanguageHeaderValues?.FirstOrDefault();
    }
}
