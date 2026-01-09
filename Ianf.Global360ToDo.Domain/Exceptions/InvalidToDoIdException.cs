namespace Ianf.Global360ToDo.Domain.Exceptions;

[Serializable]
public class InvalidToDoIdException : Exception
{
    public InvalidToDoIdException()
    { }

    public InvalidToDoIdException(string message)
        : base(message)
    { }

    public InvalidToDoIdException(string message, Exception innerException)
        : base(message, innerException)
    { }
}