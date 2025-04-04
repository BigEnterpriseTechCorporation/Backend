using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Entities;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty; // are we really need this?
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // create time
    public DateTime? UpdatedAt { get; set; } // last time of update
    public bool IsActive { get; set; } = true; // soft deletion marker
}