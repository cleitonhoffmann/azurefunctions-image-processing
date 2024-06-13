using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Contracts.Options
{
    internal interface IProcessStepOptions
    {
        string StepType { get; }
    }
}
