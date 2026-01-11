using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Repositories;

public interface IToDoRepository
{
    public Task<long> AddToDoItem(NewToDo toDo);
    public Task<List<ToDo>> RemoveToDoItem(long toDoId);
    public Task<List<ToDo>> GetToDoItems();
}