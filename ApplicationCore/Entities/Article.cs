namespace ApplicationCore.Entities;

public class Article
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    
    // navigation
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    
    public Guid? LastEditedById { get; set; }
    public User LastEditedBy { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool IsActive { get; set; }
    
    public ICollection<ArticleHistory> Histories { get; set; }
}