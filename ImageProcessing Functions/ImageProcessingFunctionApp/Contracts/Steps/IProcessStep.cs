using ImageProcessingFunctionApp.Contracts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Contracts.Steps
{
    internal interface IProcessStep/*<TProcessStepOptions> where TProcessStepOptions : class, IProcessStepOptions, new()*/
    {
        Task ExecuteAsync(string fileName, Stream fileStream/*, IProcessStepOptions options*/);
    }
}
