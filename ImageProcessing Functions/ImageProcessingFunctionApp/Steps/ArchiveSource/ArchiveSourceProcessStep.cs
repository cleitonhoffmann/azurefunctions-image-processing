using ImageProcessingFunctionApp.Contracts.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Steps.ArchiveSource
{
    internal class ArchiveSourceProcessStep : IProcessStep<ArchiveSourceProcessStepOptions>
    {
        public Task ExecuteAsync(string fileName, Stream fileStream, ArchiveSourceProcessStepOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
