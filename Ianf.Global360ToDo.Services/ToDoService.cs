using Ianf.Global360ToDo.Domain;
using Ianf.Global360ToDo.Domain.Exceptions;
using Ianf.Global360ToDo.Repositories;

namespace Ianf.Global360ToDo.Services;

public class ToDoService(IToDoRepository toDoRepository) : IToDoService
{
    private readonly IToDoRepository _toDoRepository = toDoRepository;

    public async Task<ToDoId> AddToDoItem(NewToDo newToDo)
    {
        if (string.IsNullOrEmpty(newToDo.Title)) throw new InvalidToDoTitleException();

        if (string.IsNullOrEmpty(newToDo.Contents)) throw new InvalidToDoContentsException();

        return await _toDoRepository.AddToDoItem(newToDo);
    }

    public async Task<ToDoId> RemoveToDoItem(ToDoId toDoId) => await _toDoRepository.RemoveToDoItem(toDoId);

    public async Task<List<ToDo>> GetToDoItems() => await _toDoRepository.GetToDoItems();
}

