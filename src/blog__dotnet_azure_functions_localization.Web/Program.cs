using System.Reflection;
using blog__dotnet_azure_functions_localization.Resources;
using blog__dotnet_azure_functions_localization.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(builder =>
    {
        builder.UseMiddleware<LocalizationMiddleware>();
    })
    .ConfigureServices(services =>
    {

        // Add services required for application localization
        services.AddLocalization();

        // Add string resources from 'Resources' project
        services.AddSingleton(serviceProvider =>
        {
            var localizerFactory = serviceProvider.GetRequiredService<IStringLocalizerFactory>();
            var resourcesSourceType = typeof(ResourcesAnchor);
            var assemblyName = new AssemblyName(resourcesSourceType.GetTypeInfo().Assembly.FullName);

            return localizerFactory.Create("Resources", assemblyName.Name);
        });
    })
    .Build();

host.Run();
