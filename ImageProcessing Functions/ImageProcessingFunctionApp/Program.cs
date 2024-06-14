using ImageProcessingFunctionApp.Contracts.Services;
using ImageProcessingFunctionApp.Contracts.Steps;
using ImageProcessingFunctionApp.Services;
using ImageProcessingFunctionApp.Steps;
using ImageProcessingFunctionApp.Steps.BlobUpload;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddScoped<IBlobStorageService, BlobStorageService>();

        services.AddScoped<IProcessStepBuilderCreator, ProcessStepBuilderCreator>();

        services
            .AddScoped<IProcessStepBuilder, BlobUploadProcessStepBuilder>();


    })
    .Build();

host.Run();
