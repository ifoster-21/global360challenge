using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Repositories;

public interface IToDoRepository
{
    public Task<int> AddToDoItem(NewToDo toDo);
    public Task<List<ToDo>> RemoveToDoItem(int toDoId);
    public Task<List<ToDo>> GetToDoItems();
}