using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ImageRepository(AppDbContext context) : IImageRepository
{
    private readonly AppDbContext _context = context;
    public async Task<Image?> GetByHashAsync(string hash)
    {
        return await _context.Images.FirstOrDefaultAsync(image => image.Hash == hash);
    }

    public async Task<List<Image>> GetAllAsync()
    {
        return await _context.Images.ToListAsync();
    }

    public async Task<string> CreateAsync(Image image)
    {
        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();
        return image.Hash;
    }

    public async Task DeleteAsync(string hash)
    {
        var image = await GetByHashAsync(hash);
        if (image != null)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }
    }
}