using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaBrowser
{
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly BlobServiceClient _blobServiceClient;

        public ImagesController(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        [HttpGet("images/{*filePath}")]
        public async Task<IActionResult> GetImage(string filePath)
        {
            try
            {
                var blobContainer = _blobServiceClient.GetBlobContainerClient("movies");
                var blobClient = blobContainer.GetBlobClient(filePath);
                var download = await blobClient.DownloadAsync();
                return File(download.Value.Content, $"image/jpeg");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
