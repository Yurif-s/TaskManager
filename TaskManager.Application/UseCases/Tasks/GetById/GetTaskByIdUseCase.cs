using TaskManager.Application.Infrastructure;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.GetById;

public class GetTaskByIdUseCase
{
    private readonly AppDbContext _context;
    public GetTaskByIdUseCase(AppDbContext context)
    {
        _context = context;
    }
    public ResponseTaskJson Execute(Guid id)
    {
        var entity = _context.Tasks.FirstOrDefault(t => t.Id == id);

        return new ResponseTaskJson
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            LimitDate = entity.LimitDate,
            Priority = entity.Priority,
            Status = entity.Status
        };
    }
}
