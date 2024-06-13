using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessingFunctionApp.Contracts.Services
{
    internal interface IBlobStorageService
    {
        Task<string> UploadFileAsync(string containerName, string fileName, Stream fileStream);

        Task<string> UploadFileAsync(string containerName, string fileName, Stream fileStream, IDictionary<string, string> fileTags);
    }
}
