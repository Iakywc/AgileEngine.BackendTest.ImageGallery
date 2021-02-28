using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AgileEngine.BackendTest.ImageGallery.Logic.Models;
using Newtonsoft.Json;

namespace AgileEngine.BackendTest.ImageGallery.Logic.Services
{
    public class TokenHttpClientService
    {
        public async Task<GalleryToken> PostToken(string apiKey)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var Content = new StringContent(apiKey, Encoding.UTF8, "application/json");
                    var url = "auth";

                    client.BaseAddress = new Uri("https://api.github.com");
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    
                    HttpResponseMessage response = await client.PostAsync(url, Content);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<GalleryToken>(result);
                }
            }
            catch (Exception e)
            {
                throw new Exception("We couldn't validate your identity, please try again.", e);
            }
        }
    }
}
