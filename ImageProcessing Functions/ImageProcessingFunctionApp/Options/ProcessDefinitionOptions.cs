using ImageProcessingFunctionApp.Contracts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Options
{
    internal class ProcessDefinitionOptions
    {
        public IEnumerable<IProcessStepOptions> ProcessDefinition { get; set; } = new List<IProcessStepOptions>();
    }
}
