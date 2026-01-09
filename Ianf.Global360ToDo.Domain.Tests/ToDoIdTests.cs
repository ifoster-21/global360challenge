using Ianf.Global360ToDo.Domain.Exceptions;

namespace Ianf.Global360ToDo.Domain.Tests;

public class ToDoIdTests
{
    [Fact]
    public void TestToDoIdMustBePositiveInteger()
    {
        // Assemble
        var newToDoId = -42;

        // Act - Assert
        Assert.Throws<InvalidToDoIdException>(() => new ToDoId(newToDoId));
    }
}
