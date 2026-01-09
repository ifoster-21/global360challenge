using Microsoft.AspNetCore.Mvc;
using Ianf.Global360ToDo.Services;
using Ianf.Global360ToDo.Domain;

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
    [Route("/ToDo")]
    public async Task<List<ToDo>> GetToDoItems()
    {
        return await _service.GetToDoItems();
    }

    [HttpPost]
    [Route("/ToDo")]
    public async Task<ToDoId> AddNewToDoItem(NewToDo newToDo)
    {
        return await _service.AddToDoItem(newToDo);
    }

    [HttpDelete]
    [Route("/ToDo")]
    public async Task<ToDoId> RemoveToDoItem(ToDoId toDoId)
    {
        return await _service.RemoveToDoItem(toDoId);
    }
}
