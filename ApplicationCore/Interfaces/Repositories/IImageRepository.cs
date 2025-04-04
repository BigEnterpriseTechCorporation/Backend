using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories;

public interface IImageRepository
{
    Task<Image?> GetByHashAsync(string hash);
    Task<List<Image>> GetAllAsync();
    Task<string> CreateAsync(Image image);
    Task DeleteAsync(string hash);
}