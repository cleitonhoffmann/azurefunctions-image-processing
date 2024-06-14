using ImageProcessingFunctionApp.Contracts.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Steps.BlobUpload
{
    internal class BlobUploadProcessStepOptions : IProcessStepOptions
    {
        public BlobUploadProcessStepOptions()
        {
        }

        //public BlobUploadProcessStepOptions(IDictionary<string, string> settings) 
        //{
        //    StepType = settings[nameof(StepType)]?? throw new InvalidOperationException($"Invalid Configuration. Missing 'nameof(StepType)' setting.");
        //}

        public string StepType { get; set; } = string.Empty;

        public string ContainerName { get; set; } = string.Empty;

        public string FileNameFormat { get; set; } = string.Empty;

        public bool CompressionEnabled { get; set; }

        public short CompressionQualityPercentage { get; set; }

        public bool ResizeEnabled { get; set; }

        public short ResizeMaxWidth { get; set; }

        public short ResizeMaxHeight { get; set; }
    }
}
