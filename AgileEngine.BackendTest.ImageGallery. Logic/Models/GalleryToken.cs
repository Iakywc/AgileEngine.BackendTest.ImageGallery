using System.Text.Json.Serialization;

namespace AgileEngine.BackendTest.ImageGallery.Logic.Models
{
    public class GalleryToken
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
