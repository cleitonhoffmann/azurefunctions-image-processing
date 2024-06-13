using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using ImageProcessingFunctionApp.Contracts.Services;

namespace ImageProcessingFunctionApp.Services
{
    internal class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobStorageService(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<string> UploadFileAsync(string containerName, string fileName, Stream fileStream)
        {
            var fileTags = new Dictionary<string, string>();

            return await UploadFileAsync(containerName, fileName, fileStream, fileTags);
        }

        public async Task<string> UploadFileAsync(string containerName, string fileName, Stream fileStream, IDictionary<string, string> fileTags)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

            var blobClient = containerClient.GetBlobClient(fileName);
            fileStream.Position = 0;

            await blobClient.UploadAsync(fileStream, new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = MediaTypeNames.Image.Jpeg },
                Tags = fileTags
            });

            return blobClient.Uri.AbsoluteUri;
        }
    }
}
