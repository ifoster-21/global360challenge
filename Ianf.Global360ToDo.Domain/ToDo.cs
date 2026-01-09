using Ianf.Global360ToDo.Domain.Enums;

namespace Ianf.Global360ToDo.Domain;

public readonly record struct ToDo
{
    public ToDo() { }
    public ToDoId Id { get; init; } = new ToDoId(1);
    public string Title { get; init; } = string.Empty;
    public string Contents { get; init; } = string.Empty;
    public Priority Priority { get; init; } = Priority.Medium;
    public DateTime CompletionDate { get; init; } = DateTime.MaxValue;
}
