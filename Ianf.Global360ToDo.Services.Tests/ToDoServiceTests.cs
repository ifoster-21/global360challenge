using Ianf.Global360ToDo.Domain;
using Ianf.Global360ToDo.Domain.Exceptions;
using Ianf.Global360ToDo.Repositories;
using Moq;

namespace Ianf.Global360ToDo.Services.Tests;

public class ToDoServiceTests
{
    private readonly Mock<IToDoRepository> _repositoryMock;
    private readonly IToDoService _sut;

    public ToDoServiceTests()
    {
        _repositoryMock = new Mock<IToDoRepository>();
        _sut = new ToDoService(_repositoryMock.Object);
    }

    [Fact]
    public async Task TestAddNewToDoWithInvalidTitleThrowsException()
    {
        // Assemble
        var newToDo = new NewToDo
        {
            Contents = "This is valid contents."
        };

        // Act - Assert
        await Assert.ThrowsAsync<InvalidToDoTitleException>(() => _sut.AddToDoItem(newToDo));
    }

    [Fact]
    public async Task TestAddNewToDoWithInvalidContentsThrowsException()
    {
        // Assemble
        var newToDo = new NewToDo
        {
            Title = "This is a valid title"
        };

        // Act - Assert
        await Assert.ThrowsAsync<InvalidToDoContentsException>(() => _sut.AddToDoItem(newToDo));
    }

    [Fact]
    public async Task TestAddValidNewToDo()
    {
        // Assemble
        var newToDo = new NewToDo
        {
            Title = "This is a valid title",
            Contents = "This is valid contents."
        };
        _repositoryMock
            .Setup(r => r.AddToDoItem(It.IsAny<NewToDo>()))
            .Returns(Task.FromResult((int)1));

        // Act
        var result = await _sut.AddToDoItem(newToDo);

        // Assert
        Assert.Equal(1, result);
    }

    /**
     * No test cases for service-level RemoveToDoItem or GetToDoItems as this is a direct wrapper around the underlying
     * repository layer with no additional business logic to test.
     */
}
