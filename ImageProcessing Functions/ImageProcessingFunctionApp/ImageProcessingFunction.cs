using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using ImageProcessingFunctionApp.Contracts.Steps;
using ImageProcessingFunctionApp.Options;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ImageProcessingFunctionApp
{
    internal class ImageProcessingFunction
    {
        private readonly ILogger<ImageProcessingFunction> _logger;
        private readonly ImageSourceOptions _imageSourceOptions;
        private readonly IProcessStepBuilderCreator _processStepCreator;

        public ImageProcessingFunction
        (
            ILogger<ImageProcessingFunction> logger,
            IOptions<ImageSourceOptions> imageSourceOptions,
            IProcessStepBuilderCreator processStepCreator
        )
        {
            _logger = logger;
            _imageSourceOptions = imageSourceOptions.Value;
            _processStepCreator = processStepCreator;
        }

        [Function(nameof(ImageProcessingFunction))]
        public async Task Run([BlobTrigger("%TriggerContainerName%/{name}", Connection = "BlobStorageConnection")] Stream stream, string name)
        {
            _logger.LogInformation("Blob Trigger: Received a new file '{FileName}'.", name);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var fileNameParts = name.Split(".");
            if (fileNameParts.Length < 2)
            {
                _logger.LogWarning("Missing File Extension on the file '{FileName}'.", name);

                return;
            }

            var fileExtension = fileNameParts.Last();
            if (!_imageSourceOptions.AllowedFileExtensions.Contains(fileExtension))
            {
                _logger.LogWarning("File Extension '{FileExtension}' not allowed.", fileExtension);

                return;
            }

            using var copyStream = new MemoryStream();
            stream.CopyTo(copyStream);

            foreach (var processStepOptions in _imageSourceOptions.ProcessDefinition)
            {
                _logger.LogInformation("Starting Processing-Step '{StepType}' of file '{FileName}'.", processStepOptions.StepType, name);

                copyStream.Position = 0;

                await _processStepCreator
                    .Get(processStepOptions.StepType)
                    .Build()
                    .ExecuteAsync(name, copyStream, processStepOptions);
            }

            if (_imageSourceOptions.DeleteSourceFileAfterProcessingEnabled)
            {
                _logger.LogInformation("Deleting Original File '{FileName}'.", name);


            }

            stopWatch.Stop();
            _logger.LogInformation("Blob Trigger: End file '{FileName}' execution in '{ElapsedTime}'ms.", name, stopWatch.ElapsedMilliseconds);

        }
    }
}
