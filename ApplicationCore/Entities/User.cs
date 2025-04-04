using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Entities;

public class User : IdentityUser<Guid>
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // create time
    public DateTime? UpdatedAt { get; set; } // last time of update
    public bool IsActive { get; set; } = true; // soft deletion marker
    [Required]
    [RegularExpression(@"^[А-Яа-я\s]+$", ErrorMessage = "ФИО должно содержать только русские буквы.")]
    public string FullName { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Логин должен содержать только латинские буквы.")]
    public override string UserName { get; set; } = string.Empty;
    
    public string Role { get; set; } = "Member";
    
    // Navigation
    public ICollection<Article> AuthoredArticles { get; set; }
    public ICollection<Article> EditedArticles { get; set; }
    public ICollection<Assignment> CreatedAssignments { get; set; }
    public ICollection<Assignment> ResponsibleAssignments { get; set; }
    public ICollection<ArticleHistory> ArticleHistories { get; set; }
    // assigment history
}