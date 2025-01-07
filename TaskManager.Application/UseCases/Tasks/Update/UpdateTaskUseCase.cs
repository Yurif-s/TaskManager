using TaskManager.Application.Infrastructure;
using TaskManager.Communication.Requests;

namespace TaskManager.Application.UseCases.Tasks.Update;

public class UpdateTaskUseCase
{
    private readonly AppDbContext _context;
    public UpdateTaskUseCase(AppDbContext context)
    {
        _context = context;
    }

    public void Execute(Guid id, RequestTaskJson request)
    {
        var entity = _context.Tasks.FirstOrDefault(task => task.Id == id);

        if (entity == null)
            throw new KeyNotFoundException();

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Status = request.Status;
        entity.LimitDate = request.LimitDate;
        entity.Priority = request.Priority;

        _context.Tasks.Update(entity);
        _context.SaveChanges();

    }
}
