using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Contracts.Steps
{
    internal interface IProcessStepBuilder/*<TProcessStepOptions> where TProcessStepOptions : class, IProcessStepOptions, new()*/
    {
        string StepType { get; }

        IProcessStep Build(IDictionary<string, string> settings);
    }
}
