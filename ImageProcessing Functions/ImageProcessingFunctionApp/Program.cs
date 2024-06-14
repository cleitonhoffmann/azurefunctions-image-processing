using ImageProcessingFunctionApp.Contracts.Services;
using ImageProcessingFunctionApp.Contracts.Steps;
using ImageProcessingFunctionApp.Options;
using ImageProcessingFunctionApp.Services;
using ImageProcessingFunctionApp.Steps;
using ImageProcessingFunctionApp.Steps.BlobUpload;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .Build();

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.Configure<ImageSourceOptions>(configuration.GetSection(ImageSourceOptions.OPTIONS_NAME));

        services.AddScoped<IBlobStorageService, BlobStorageService>();

        services
            .AddScoped<IProcessStepBuilderCreator, ProcessStepBuilderCreator>()
            .AddScoped<IProcessStepBuilder, BlobUploadProcessStepBuilder>();


    })
    .Build();

host.Run();
