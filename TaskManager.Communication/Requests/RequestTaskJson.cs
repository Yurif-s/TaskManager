using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Requests;

public class RequestTaskJson
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public PriorityType Priority { get; set; }
    public DateTime LimitDate { get; set; }
}
