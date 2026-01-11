using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Repositories.InMemory;

public class InMemoryToDoRepository : IToDoRepository
{
    private readonly List<ToDo> _todoItems = [
        new ToDo {
            Id = 1,
            Title = "",
            Contents = ""
        },
        new ToDo {
            Id = 2,
            Title = "",
            Contents = ""
        },
        new ToDo {
            Id = 3,
            Title = "",
            Contents = ""
        },
        new ToDo {
            Id = 4,
            Title = "",
            Contents = ""
        }
    ];

    private int GenerateNewToDoId() => _todoItems.Count + 1;

    public Task<int> AddToDoItem(NewToDo newToDo)
    {
        var newToDoId = GenerateNewToDoId();
        _todoItems.Add(new ToDo
        {
            Id = newToDoId,
            Title = newToDo.Title,
            Contents = newToDo.Contents
        });
        return Task.FromResult(newToDoId);
    }

    public Task<List<ToDo>> GetToDoItems() => Task.FromResult(_todoItems);

    public Task<List<ToDo>> RemoveToDoItem(int toDoId)
    {
        if (_todoItems.Exists(item => item.Id == toDoId))
        {
            var itemToRemove = _todoItems.First(item => item.Id == toDoId);
            var result = _todoItems.Remove(itemToRemove);
        }
        return Task.FromResult(_todoItems);
    }
}