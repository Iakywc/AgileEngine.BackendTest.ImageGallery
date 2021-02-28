using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AgileEngine.BackendTest.ImageGallery.Logic.Models;
using Microsoft.Extensions.Configuration;

namespace AgileEngine.BackendTest.ImageGallery.Logic.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenHttpClientService _tokenClient;

        public TokenService(IConfiguration configuration, ITokenHttpClientService tokenClient)
        {
            _configuration = configuration;
            _tokenClient = tokenClient;
        }

        public async Task<GalleryToken> GetToken()
        {
            var apiKey = _configuration.GetSection("TokenInfo:ApiKey").Value;

            return await _tokenClient.PostTokenRequest(apiKey);
        }

        public async Task<GalleryToken> RenewToken()
        {
            return await GetToken();
        }

        public async Task<GalleryToken> IsValidToken(string token)
        {
            var prevToken = await GetToken();
            if (prevToken.Token.Equals(token))
            {
                return prevToken;
            }

            return await RenewToken();
        }
    }
}
