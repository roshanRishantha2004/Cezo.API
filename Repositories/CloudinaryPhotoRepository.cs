
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace Cezo.API.Repositories
{
    public class CloudinaryPhotoRepository : IPhotoRepository
    {
        private readonly Cloudinary cloudinary;

        public CloudinaryPhotoRepository(Cloudinary cloudinary) { 
            this.cloudinary = cloudinary;
        }
        public async Task<ImageUploadResult> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length <= 0)
                throw new ArgumentException("Invalid file.");

            var uploadParams = new ImageUploadParams
            {
                File = new CloudinaryDotNet.FileDescription(file.FileName, file.OpenReadStream()),
                Folder = "images",
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            return uploadResult;

        }
    }
}
