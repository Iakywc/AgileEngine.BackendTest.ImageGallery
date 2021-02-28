using System.Collections.Generic;
using System.Threading.Tasks;
using AgileEngine.BackendTest.ImageGallery.Logic;
using AgileEngine.BackendTest.ImageGallery.Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgileEngine.BackendTest.ImageGallery.API.Controllers
{
    public class GalleryController : ControllerBase
    {
        private readonly IImageGallery _imageGallery;
        public GalleryController(IImageGallery imageGallery)
        {
            _imageGallery = imageGallery;
        }

        [HttpGet("Images")]
        public async Task<ActionResult<IEnumerable<ImageInfo>>> GetImage()
        {
            //TODO: Add Fluent Validation or some other validation

            var response = await _imageGallery.GetImages();

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}
