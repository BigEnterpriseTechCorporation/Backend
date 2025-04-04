using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Services;

public interface IImageService
{
    Task<Image?> GetByHashAsync(string hash);
    Task<List<Image>> GetAllAsync();
    Task<string> CreateAsync(byte[] imageBytes, Guid uploadedById);
    Task DeleteAsync(string hash);
}