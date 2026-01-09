using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Repositories.InMemory;

public class InMemoryToDoRepository : IToDoRepository
{
    private readonly List<ToDo> _todoItems = [];

    private ToDoId GenerateNewToDoId()
    {
        var todoCount = _todoItems.Count;
        return new ToDoId(todoCount + 1);
    }

    public Task<ToDoId> AddToDoItem(NewToDo newToDo)
    {
        var newToDoId = GenerateNewToDoId();
        var toDo = new ToDo
        {
            Id = newToDoId,
            Title = newToDo.Title,
            Contents = newToDo.Contents,
            Priority = newToDo.Priority
        };
        _todoItems.Add(toDo);
        return Task.FromResult(newToDoId);
    }

    public Task<IEnumerable<ToDo>> GetToDos() => Task.FromResult(_todoItems.AsEnumerable());

    public Task RemoveToDoItem(ToDoId toDoId)
    {
        throw new NotImplementedException();
    }
}