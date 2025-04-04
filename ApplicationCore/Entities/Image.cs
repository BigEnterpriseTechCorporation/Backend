using Microsoft.AspNetCore.Http.HttpResults;

namespace ApplicationCore.Entities;

public class Image
{
    public string Hash { get; set; }
    public byte[] ImageData { get; set; }
    
    public Guid UploadedById { get; set; }
    public User UploadedBy { get; set; }
    
    public DateTime CreatedDate { get; set; }
}