using Microsoft.Azure.Functions.Worker.Http;

namespace blog__dotnet_azure_functions_localization;

public interface IRequestCultureProvider
{
    string? GetCulture(HttpRequestData request);
}
