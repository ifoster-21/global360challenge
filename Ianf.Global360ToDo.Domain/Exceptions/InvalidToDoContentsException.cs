namespace Ianf.Global360ToDo.Domain.Exceptions;

[Serializable]
public class InvalidToDoContentsException : Exception
{
    public InvalidToDoContentsException()
    { }

    public InvalidToDoContentsException(string message)
        : base(message)
    { }

    public InvalidToDoContentsException(string message, Exception innerException)
        : base(message, innerException)
    { }
}