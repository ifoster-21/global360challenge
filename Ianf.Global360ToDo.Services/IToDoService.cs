using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Services;

public interface IToDoService
{
    public Task<ToDoId> AddToDoItem(NewToDo newToDo);
    public Task<ToDoId> RemoveToDoItem(ToDoId toDoId);
    public Task<List<ToDo>> GetToDoItems();
}