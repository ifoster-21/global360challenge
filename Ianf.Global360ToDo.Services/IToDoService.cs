using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Services;

public interface IToDoService
{
    public Task<ToDoId> AddToDoItem(NewToDo newToDo);
}