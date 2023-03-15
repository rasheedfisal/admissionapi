namespace admissionapi.api.Services;
    public interface IImageProcessor
    {
        Task<string?> SaveImageAsync(IFormFile? file);
        Task<string?> SaveAllFormatAsync(IFormFile? file);
        Task<bool> RemoveImageAsync(string filePath);
    }

