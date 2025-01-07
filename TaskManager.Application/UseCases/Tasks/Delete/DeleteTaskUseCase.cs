using TaskManager.Application.Infrastructure;

namespace TaskManager.Application.UseCases.Tasks.Delete;

public class DeleteTaskUseCase
{
    private readonly AppDbContext _context;
    public DeleteTaskUseCase(AppDbContext context)
    {
        _context = context;
    }
    public void Execute(Guid id)
    {
        var entity = _context.Tasks.FirstOrDefault(task => task.Id == id);

        if (entity == null)
            throw new KeyNotFoundException();

        _context.Tasks.Remove(entity);
        _context.SaveChanges();
    }
}
