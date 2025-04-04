namespace ApplicationCore.Entities;

public class ArticleHistory
{
    public Guid Id { get; set; }
    public DateTime ChangeDate { get; set; }
    
    public string Diff { get; set; }
    
    public Guid ArticleId { get; set; }
    public Article Article { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}