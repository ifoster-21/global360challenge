using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Services;

public interface IToDoService
{
    public Task<long> AddToDoItem(NewToDo newToDo);
    public Task<List<ToDo>> RemoveToDoItem(long toDoId);
    public Task<List<ToDo>> GetToDoItems();
}