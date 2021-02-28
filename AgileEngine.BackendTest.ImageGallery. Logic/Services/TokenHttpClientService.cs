using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AgileEngine.BackendTest.ImageGallery.Logic.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AgileEngine.BackendTest.ImageGallery.Logic.Services
{
    public class TokenHttpClientService : ITokenHttpClientService
    {
        private readonly IConfiguration _configuration;

        public TokenHttpClientService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<GalleryToken> PostTokenRequest(string apiKey)
        {
            try
            {
                using var client = new HttpClient();
                var content = new StringContent(apiKey, Encoding.UTF8, "application/json");
                var baseUrl = new Uri(_configuration.GetSection("TokenInfo:BaseUrl").Value);
                var url = "auth";

                client.BaseAddress = baseUrl;
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GalleryToken>(result);
            }
            catch (Exception e)
            {
                throw new Exception("We couldn't validate your identity, please try again.", e);
            }
        }
    }
}
