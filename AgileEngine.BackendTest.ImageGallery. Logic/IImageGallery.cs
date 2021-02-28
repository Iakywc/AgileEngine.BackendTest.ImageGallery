using System.Collections.Generic;
using System.Threading.Tasks;
using AgileEngine.BackendTest.ImageGallery.Logic.Models;

namespace AgileEngine.BackendTest.ImageGallery.Logic
{
    public interface IImageGallery
    {
        Task<IEnumerable<ImageInfo>> GetImages();
        Task<IEnumerable<ImageInfo>> GetImagesInPage(string page);
        Task<ImageInfo> GetImageById(string id);
    }
}