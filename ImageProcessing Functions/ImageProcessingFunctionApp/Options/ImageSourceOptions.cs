using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Options
{
    public class ImageSourceOptions
    {
        public const string OPTIONS_NAME = "ImageSource";

        public string TriggerContainerName { get; set; } = string.Empty;

        public IEnumerable<string> AllowedFileExtensions { get; set; } = new List<string>();

        public bool DeleteSourceFileAfterProcessingEnabled { get; set; }

        public bool FileLogEnabled { get; set; }

        public string FileLogContainerName { get; set; } = string.Empty;

        public IEnumerable<ProcessDefinitionItemOptions> ProcessDefinition { get; set; } = new List<ProcessDefinitionItemOptions>();
    }
}
