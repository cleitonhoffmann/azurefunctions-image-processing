using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Contracts.Steps
{
    internal interface IProcessStep
    {
        Task ExecuteAsync/*<TProcessStepOptions>*/(string fileName, Stream fileStream/*, TProcessStepOptions options*/); 
            //where TProcessStepOptions : class, IProcessStepOptions, new();
    }
}
