namespace Ianf.Global360ToDo.Domain;

public readonly record struct NewToDo
{
    public NewToDo() { }
    public string Title { get; init; } = string.Empty;
    public string Contents { get; init; } = string.Empty;
}