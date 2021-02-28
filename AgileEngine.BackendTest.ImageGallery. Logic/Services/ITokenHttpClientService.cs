using System.Threading.Tasks;
using AgileEngine.BackendTest.ImageGallery.Logic.Models;

namespace AgileEngine.BackendTest.ImageGallery.Logic.Services
{
    public interface ITokenHttpClientService
    {
        Task<GalleryToken> PostTokenRequest(string apiKey);
    }
}