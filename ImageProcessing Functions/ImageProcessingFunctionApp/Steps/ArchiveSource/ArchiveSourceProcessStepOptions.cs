using ImageProcessingFunctionApp.Contracts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Steps.ArchiveSource
{
    internal class ArchiveSourceProcessStepOptions : IProcessStepOptions
    {
        public string StepType { get; set; } = string.Empty;
    }
}
