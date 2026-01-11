namespace Ianf.Global360ToDo.Domain;

public readonly record struct ToDo
{
    public ToDo() { }
    public long Id { get; init; } = 0;
    public string Title { get; init; } = string.Empty;
    public string Contents { get; init; } = string.Empty;
}
