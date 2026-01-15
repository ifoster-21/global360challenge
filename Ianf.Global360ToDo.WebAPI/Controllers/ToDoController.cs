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
    private readonly ILogger<ToDoController> _logger;

    public ToDoController(IToDoService service, ILogger<ToDoController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    [Route("/ToDoItems")]
    public async Task<List<ToDo>> GetToDoItems()
    {
        return await _service.GetToDoItems();
    }

    [HttpPost]
    [Route("/ToDoItems")]
    public async Task<ActionResult<long>> AddNewToDoItem(NewToDo newToDo)
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
    public async Task<List<ToDo>> RemoveToDoItem(int toDoId)
    {
        return await _service.RemoveToDoItem(toDoId);
    }
}
