using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Infrastructure;
using TaskManager.Application.UseCases.Tasks.Register;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;
    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Register(RequestTaskJson request)
    {
        var useCase = new RegisterTaskUseCase(_context);
            
        var response = useCase.Execute(request);

        return Created(String.Empty, response);
    }
}
