using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Responses;

public class ResponseTaskJson
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public PriorityType Priority { get; set; }
    public DateTime LimitDate { get; set; }
    public StatusType Status { get; set; }
}
