using System.Globalization;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace blog__dotnet_azure_functions_localization.Web;

public class LocalizationMiddleware : IFunctionsWorkerMiddleware
{
    private static readonly IList<IRequestCultureProvider> RequestCultureProviders =
    [
        new AcceptLanguageHeaderRequestCultureProvider(),
        new QueryStringRequestCultureProvider()
    ];

    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var requestData = await context.GetHttpRequestDataAsync();
        if (requestData != null)
        {
            SetCurrentThreadCulture(requestData);
        }

        await next(context);
    }

    private static void SetCurrentThreadCulture(HttpRequestData requestData)
    {
        foreach (var provider in RequestCultureProviders)
        {
            var culture = provider.GetCulture(requestData);
            if (string.IsNullOrEmpty(culture))
            {
                continue;
            }

            CultureInfo.CurrentUICulture = new CultureInfo(culture);
            break;
        }
    }
}
