using FoodRecipe.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipe.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileuploadController : ControllerBase
    {
        private readonly IMinioService _minioService;
        public FileuploadController(IMinioService _minioservice)
        {
            this._minioService = _minioservice;
        }

        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File required");

            var objectName = await _minioService.UploadAsync(
                file.OpenReadStream(),
                file.FileName,
                file.ContentType
            );

            var url = await _minioService.GetPresingedUrlAsync(objectName);

            return Ok(new { objectName, url });
        }
    }
}
