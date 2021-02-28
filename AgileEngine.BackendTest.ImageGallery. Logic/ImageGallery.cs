using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgileEngine.BackendTest.ImageGallery.Logic.Models;
using AgileEngine.BackendTest.ImageGallery.Logic.Services;

namespace AgileEngine.BackendTest.ImageGallery.Logic
{
    public class ImageGallery
    {
        private readonly IImageHttpClientService _imageClient;
        private readonly ITokenService _tokenService;
        private static string token;
        public ImageGallery(IImageHttpClientService imageClient, ITokenService tokenService)
        {
            _imageClient = imageClient;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<ImageInfo>> GetImages()
        {
            ValidateToken();

            return await _imageClient.GetImagesRequest(token, "GetImages");
        }

        public async Task<IEnumerable<ImageInfo>> GetImagesInPage(string page)
        {
            ValidateToken();

            return await _imageClient.GetImagesRequest(token, $"GetImages/?page={page}");
        }

        public async Task<ImageInfo> GetImageById(string id)
        {
            ValidateToken();

            var images = await _imageClient.GetImagesRequest(token, $"GetImages/id");

            return images.FirstOrDefault();
        }

        /*
        public async Task<ImageInfo> GetImagesByTerm(string term)
         
        {
            //TODO: Implement Cache to retrieve funcitonality from it.
        }
        */

        private async void ValidateToken()
        {
            if (string.IsNullOrEmpty(token))
                CreateToken();
            else
            {
                var newToken = await _tokenService.IsValidToken(token);
                token = newToken.Token;
            }
        }

        private async void CreateToken()
        {
            var newToken = await _tokenService.GetToken();
            token = newToken.Token;
        }
    }
}
