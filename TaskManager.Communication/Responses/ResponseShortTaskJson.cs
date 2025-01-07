using TaskManager.Communication.Enums;

namespace TaskManager.Communication.Responses;

public class ResponseShortTaskJson
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public DateTime LimitDate { get; set; }
    public StatusType Status { get; set; }
}
