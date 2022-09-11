namespace BookStore.Core.Services
{
    public interface IFileManager
    {
        string SaveFile(IFormFile file);
        void DeleteFile(string path);
    }
}
