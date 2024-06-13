using ImageProcessingFunctionApp.Contracts.Services;
using ImageProcessingFunctionApp.Contracts.Steps;
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

        public IProcessStep Build()
        {
            var options = _serviceProvider.GetRequiredService<IOptions<BlobUploadProcessStepOptions>>();
            var blobStorageService = _serviceProvider.GetRequiredService<IBlobStorageService>();

            return new BlobUploadProcessStep(options, blobStorageService);
        }
    }
}
