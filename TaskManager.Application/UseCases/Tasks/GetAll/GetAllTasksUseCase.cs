using TaskManager.Application.Infrastructure;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.GetAll;

public class GetAllTasksUseCase
{
    private readonly AppDbContext _context;
    public GetAllTasksUseCase(AppDbContext context)
    {
        _context = context;
    }

    public ResponseAllTasksJson Execute()
    {
        var entities = _context.Tasks.ToList();

        var entity = entities.Select(entity => new ResponseShortTaskJson
        {
            Id = entity.Id,
            Name = entity.Name,
            LimitDate = entity.LimitDate,
            Status = entity.Status
        }).ToList();

        return new ResponseAllTasksJson
        {
            Tasks = entity
        };

    }
}
