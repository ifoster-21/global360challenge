namespace Ianf.Global360ToDo.Domain.Exceptions;

[Serializable]
public class InvalidToDoTitleException : Exception
{
    public InvalidToDoTitleException()
    { }

    public InvalidToDoTitleException(string message)
        : base(message)
    { }

    public InvalidToDoTitleException(string message, Exception innerException)
        : base(message, innerException)
    { }
}