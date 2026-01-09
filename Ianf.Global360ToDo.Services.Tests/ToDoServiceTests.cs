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
            Contents = "This is valid contents.",
            Priority = Domain.Enums.Priority.High,
            CompletionDate = DateTime.Now
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
            Title = "This is a valid title",
            Priority = Domain.Enums.Priority.High,
            CompletionDate = DateTime.Now
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
            Contents = "This is valid contents.",
            Priority = Domain.Enums.Priority.High,
            CompletionDate = DateTime.Now
        };
        _repositoryMock
            .Setup(r => r.AddToDoItem(It.IsAny<NewToDo>()))
            .Returns(Task.FromResult(new ToDoId(1)));

        // Act
        var result = await _sut.AddToDoItem(newToDo);

        // Assert
        Assert.Equal(new ToDoId(1), result);
    }
}
