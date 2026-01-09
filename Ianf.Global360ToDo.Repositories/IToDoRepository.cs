using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Repositories;

public interface IToDoRepository
{
    public Task<ToDoId> AddToDoItem(ToDo toDo);
    public Task RemoveToDoItem(int toDoId);
    public Task<IEnumerable<ToDo>> GetToDos();
}