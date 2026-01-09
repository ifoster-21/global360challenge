using Ianf.Global360ToDo.Domain.Exceptions;

namespace Ianf.Global360ToDo.Domain;

public readonly record struct ToDoId
{
    public int Id { get; init; } = 0;

    public ToDoId(int id)
    {
        IsValid(id);
        this.Id = id;
    }

    private void IsValid(int id)
    {
        if (id <= 0)
        {
            throw new InvalidToDoIdException($"Invalid id {id}. Id provided must be greater than zero.");
        }
    }
}