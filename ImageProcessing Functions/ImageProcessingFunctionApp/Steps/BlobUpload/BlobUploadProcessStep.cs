using ImageProcessingFunctionApp.Contracts.Services;
using ImageProcessingFunctionApp.Contracts.Steps;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Steps.BlobUpload
{
    internal class BlobUploadProcessStep : IProcessStep
    {
        private readonly BlobUploadProcessStepOptions _options;
        private readonly IBlobStorageService _blobStorageService;

        public BlobUploadProcessStep(IOptions<BlobUploadProcessStepOptions> options, IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
            _options = options.Value;
        }

        public Task ExecuteAsync(string fileName, Stream fileStream)
        {
            throw new NotImplementedException();
        }
    }
}
