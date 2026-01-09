using Ianf.Global360ToDo.Domain;

namespace Ianf.Global360ToDo.Repositories.InMemory;

public class InMemoryToDoRepository : IToDoRepository
{
    public Task<ToDoId> AddToDoItem(ToDo toDo)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ToDo>> GetToDos()
    {
        throw new NotImplementedException();
    }

    public Task RemoveToDoItem(int toDoId)
    {
        throw new NotImplementedException();
    }
}