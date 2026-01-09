using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Repositories.InMemory;

public class InMemoryToDoRepository : IToDoRepository
{
    private readonly List<ToDo> _todoItems = [];

    private ToDoId GenerateNewToDoId() => new(_todoItems.Count + 1);

    public Task<ToDoId> AddToDoItem(NewToDo newToDo)
    {
        var newToDoId = GenerateNewToDoId();
        _todoItems.Add(new ToDo
        {
            Id = newToDoId,
            Title = newToDo.Title,
            Contents = newToDo.Contents,
            Priority = newToDo.Priority
        });
        return Task.FromResult(newToDoId);
    }

    public Task<IEnumerable<ToDo>> GetToDos() => Task.FromResult(_todoItems.AsEnumerable());

    public Task<ToDoId> RemoveToDoItem(ToDoId toDoId)
    {
        if(_todoItems.Exists(item => item.Id == toDoId))
        {
            var itemToRemove = _todoItems.First(item => item.Id == toDoId);
            var result = _todoItems.Remove(itemToRemove);
        }
        return Task.FromResult(toDoId);
    }
}