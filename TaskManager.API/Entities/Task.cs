namespace TaskManager.API.Entities;

public class Task
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public DateTime LimitDate { get; set; }
    public string Status { get; set; }
}
