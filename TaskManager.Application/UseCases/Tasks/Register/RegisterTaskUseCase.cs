using TaskManager.Application.Infrastructure;
using TaskManager.Application.Entities;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.Register
{
    public class RegisterTaskUseCase
    {
        private readonly AppDbContext _context;
        public RegisterTaskUseCase(AppDbContext context)
        {
            _context = context;
        }

        public ResponseShortTaskJson Execute(RequestTaskJson request)
        {
            var entity = new TaskItem
            {
                Name = request.Name,
                Description = request.Description,
                LimitDate = request.LimitDate,
                Priority = request.Priority,
            };

            _context.Tasks.Add(entity);
            _context.SaveChanges();

            return new ResponseShortTaskJson
            {
                Id = entity.Id,
                Name = entity.Name,
                LimitDate = entity.LimitDate,
                Status = entity.Status
            };
        }
    }
}
