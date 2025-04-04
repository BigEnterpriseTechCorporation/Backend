using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Assignment
{
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    
    public string Content { get; set; }
    public string ImageHash { get; set; }
    
    public AssignmentStatus Status { get; set; }
    public Priority Priority { get; set; }
    
    public Guid CreatorId { get; set; }
    public User Creator { get; set; }
    
    public Guid ResponsibleUserId { get; set; }
    public User ResponsibleUser { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? PlannedDate { get; set; }
}

public enum AssignmentStatus
{
    Current,
    OnHold,
    Completed
}

public enum Priority
{
    Low,
    Medium,
    High
}