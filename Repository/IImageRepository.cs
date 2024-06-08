using NzApp.Model.Domain;

namespace NzApp.Repository
{
    public interface IImageRepository
    {
        Task<Image>Upload(Image image);
    }
}
