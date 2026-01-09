using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Repositories;

public interface IToDoRepository
{
    public Task<ToDoId> AddToDoItem(NewToDo toDo);
    public Task<ToDoId> RemoveToDoItem(ToDoId toDoId);
    public Task<IEnumerable<ToDo>> GetToDos();
}