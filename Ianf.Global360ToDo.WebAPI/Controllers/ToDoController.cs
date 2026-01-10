using Microsoft.AspNetCore.Mvc;
using Ianf.Global360ToDo.Services;
using Ianf.Global360ToDo.Domain;
using Ianf.Global360ToDo.Domain.Exceptions;

namespace Ianf.Global360ToDo.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _service;
    private readonly ILogger<ToDoService> _logger;

    public ToDoController(IToDoService service, ILogger<ToDoService> logger)
    {
        _service = service;
        _logger = logger;
        _logger.LogInformation("ToDoController Started");
    }

    [HttpGet]
    [Route("/ToDoItems")]
    public async Task<List<ToDo>> GetToDoItems()
    {
        return await _service.GetToDoItems();
    }

    [HttpPost]
    [Route("/ToDoItems")]
    public async Task<ActionResult<int>> AddNewToDoItem(NewToDo newToDo)
    {
        try
        {
            return await _service.AddToDoItem(newToDo);
        }
        catch (InvalidToDoTitleException ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
        catch (InvalidToDoContentsException ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("/ToDoItems/{toDoId}")]
    public async Task<IActionResult> RemoveToDoItem(int toDoId)
    {
        _logger.LogInformation($"Called Delete Item with {toDoId}.");
        try
        {
            await _service.RemoveToDoItem(toDoId);
        }
        catch (InvalidToDoIdException)
        {
            return BadRequest($"Id {toDoId} is not a valid id for a ToDoItem.");
        }
        return Ok();
    }
}
