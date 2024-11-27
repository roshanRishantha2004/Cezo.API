using CloudinaryDotNet.Actions;

namespace Cezo.API.Repositories
{
    public interface IPhotoRepository
    {
        Task<ImageUploadResult> UploadImageAsync(IFormFile file);
    }
}
