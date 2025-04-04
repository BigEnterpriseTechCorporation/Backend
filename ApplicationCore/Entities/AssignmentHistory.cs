namespace ApplicationCore.Entities;

public class AssignmentHistory
{
    public Guid Id { get; set; }
    public DateTime ChangeDate { get; set; }
    public HistoryEventType EventType { get; set; }
    
    public Guid AssignmentId { get; set; }
    public Assignment Assignment { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}