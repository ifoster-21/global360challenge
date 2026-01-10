using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Services;

public interface IToDoService
{
    public Task<int> AddToDoItem(NewToDo newToDo);
    public Task<List<ToDo>> RemoveToDoItem(int toDoId);
    public Task<List<ToDo>> GetToDoItems();
}