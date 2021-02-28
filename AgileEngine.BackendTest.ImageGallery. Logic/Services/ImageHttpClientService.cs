using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AgileEngine.BackendTest.ImageGallery.Logic.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AgileEngine.BackendTest.ImageGallery.Logic.Services
{
    public class ImageHttpClientService : IImageHttpClientService
    {
        private readonly IConfiguration _configuration;

        public ImageHttpClientService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<ImageInfo>> GetImagesRequest(string token, string extendedUrl)
        {
            try
            {
                using var client = new HttpClient();
                var baseUrl = new Uri(_configuration.GetSection("TokenInfo:BaseUrl").Value);
                var url = extendedUrl;

                client.BaseAddress = baseUrl;
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<ImageInfo>>(result);
            }
            catch (Exception e)
            {
                throw new Exception("We couldn't find images, please try again.", e);
            }
        }
    }
}
