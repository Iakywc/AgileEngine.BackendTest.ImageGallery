using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileEngine.BackendTest.ImageGallery.API.Controllers
{
    public class GalleryController : ControllerBase
    {
        [HttpGet("Image")]
        public async Task<ActionResult> GetImage()
        {


            return Ok();
        }
    }
}
