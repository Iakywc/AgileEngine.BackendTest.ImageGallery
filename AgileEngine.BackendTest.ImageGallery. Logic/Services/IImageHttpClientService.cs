using System.Collections.Generic;
using System.Threading.Tasks;
using AgileEngine.BackendTest.ImageGallery.Logic.Models;

namespace AgileEngine.BackendTest.ImageGallery.Logic.Services
{
    public interface IImageHttpClientService
    {
        Task<IEnumerable<ImageInfo>> GetImagesRequest(string token, string extendedUrl);
    }
}