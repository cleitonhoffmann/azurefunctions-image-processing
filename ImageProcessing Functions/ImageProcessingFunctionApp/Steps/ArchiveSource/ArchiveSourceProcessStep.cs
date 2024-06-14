using ImageProcessingFunctionApp.Contracts.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Steps.ArchiveSource
{
    internal class ArchiveSourceProcessStep : IProcessStep
    {
        public Task ExecuteAsync(string fileName, Stream fileStream)
        {
            throw new NotImplementedException();
        }
    }
}
