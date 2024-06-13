using ImageProcessingFunctionApp.Contracts.Steps;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Steps
{
    internal class ProcessStepBuilderCreator : IProcessStepBuilderCreator
    {
        private readonly IEnumerable<IProcessStepBuilder> _processStepBuilders;

        public ProcessStepBuilderCreator(IEnumerable<IProcessStepBuilder> processStepBuilders)
        {
            _processStepBuilders = processStepBuilders;
        }

        public IProcessStepBuilder Get(string typeName)
        {
            var builder = _processStepBuilders.FirstOrDefault(x => x.StepType ==  typeName);
            if (builder is null)
            {
                throw new InvalidOperationException($"Missing ProcessStepBuilder for the type '{typeName}'.");
            }

            return builder;
        }
    }
}
