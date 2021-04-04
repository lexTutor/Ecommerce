using BLOGIT.Models.ViewModels;

namespace BLOGIT.Repository
{
    public interface IImageProcessorService
    {
        string ImageUpload<T>(T model) where T : IWithPhotoUpload;
    }
}