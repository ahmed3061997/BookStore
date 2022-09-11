namespace BookStore.Core.Services
{
    public class FileManager : IFileManager
    {
        private readonly IWebHostEnvironment env;
        private readonly string uploadFolder = "/uploads";

        public FileManager(IWebHostEnvironment env)
        {
            this.env = env;
        }

        public void DeleteFile(string path)
        {
            var fullPath = $"{env.WebRootPath}{uploadFolder}/{path}";
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public string SaveFile(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName);
            var imgPath = $"{uploadFolder}/{file.Name}_{DateTime.Now.Ticks}{ext}";
            using (var stream = new FileStream($"{env.WebRootPath}{imgPath}", FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return imgPath;
        }
    }
}
