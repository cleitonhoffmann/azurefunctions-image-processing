using ImageProcessingFunctionApp.Contracts.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Options
{
    public class ProcessDefinitionItemOptions
    {
        public string StepType { get; set; } = string.Empty;

        public IDictionary<string, string> Settings { get; set; } = new Dictionary<string, string>();
    }
}
