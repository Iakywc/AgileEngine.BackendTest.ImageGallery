using System.Threading.Tasks;
using AgileEngine.BackendTest.ImageGallery.Logic.Models;

namespace AgileEngine.BackendTest.ImageGallery.Logic.Services
{
    public interface ITokenService
    {
        Task<GalleryToken> GetToken();
        Task<GalleryToken> RenewToken();
        Task<GalleryToken> IsValidToken(string token);
    }
}