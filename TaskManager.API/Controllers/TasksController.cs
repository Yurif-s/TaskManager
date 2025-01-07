using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManager.Application.Infrastructure;
using TaskManager.Application.UseCases.Tasks.Delete;
using TaskManager.Application.UseCases.Tasks.GetAll;
using TaskManager.Application.UseCases.Tasks.GetById;
using TaskManager.Application.UseCases.Tasks.Register;
using TaskManager.Application.UseCases.Tasks.Update;
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

        try
        {
            var response = useCase.Execute(request);
            return Created(String.Empty, response);
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTasksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get()
    {
        try
        {
            var useCase = new GetAllTasksUseCase(_context);

            var response = useCase.Execute();

            if (response is null)
                return NoContent();

            return Ok(response);
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
        
    }
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] Guid id)
    {
        var useCase = new GetTaskByIdUseCase(_context);

        var response = useCase.Execute(id);

        if (response is null)
            return NotFound("Task not found");

        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Put([FromRoute] Guid id, [FromBody] RequestTaskJson request)
    {
        var useCase = new UpdateTaskUseCase(_context);

        try
        {
            useCase.Execute(id, request);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Task not found");
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        var useCase = new DeleteTaskUseCase(_context);

        try
        {
            useCase.Execute(id);
        }
        catch(KeyNotFoundException)
        {
            return NotFound("Task not found");
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        return NoContent();
    }
}
