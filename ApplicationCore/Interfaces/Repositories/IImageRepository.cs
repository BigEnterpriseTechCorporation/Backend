using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories;

public interface IImageRepository
{
    Task<Image?> GetByHashAsync(string hash);
    Task<List<string>> GetAllAsync();
    Task<string> CreateAsync(Image image);
    Task DeleteAsync(string hash);
}