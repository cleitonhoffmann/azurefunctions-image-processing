using ImageProcessingFunctionApp.Contracts.Services;
using ImageProcessingFunctionApp.Contracts.Steps;
using ImageProcessingFunctionApp.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Steps.BlobUpload
{
    internal class BlobUploadProcessStepBuilder : IProcessStepBuilder
    {
        private readonly IServiceProvider _serviceProvider;

        public string StepType => "blob-upload";

        public BlobUploadProcessStepBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IProcessStep Build(IDictionary<string, string> settings)
        {
            var options = new BlobUploadProcessStepOptions();
            var optionsType = options.GetType();

            foreach (var key in settings.Keys)
            {
                var property = optionsType.GetProperty(key);
                if (property is null)
                {
                    throw new InvalidOperationException($"Invalid Configuration to create '{nameof(BlobUploadProcessStepOptions)}' object. Missing '{key}' setting.");
                }

                property.SetValue(options, settings[key]);
            }

            var blobStorageService = _serviceProvider.GetRequiredService<IBlobStorageService>();

            return new BlobUploadProcessStep(options, blobStorageService);
        }
    }
}
