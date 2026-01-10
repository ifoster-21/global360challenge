namespace Ianf.Global360ToDo.WebAPI.Tests;

using Ianf.Global360ToDo.Domain;
using Newtonsoft.Json;
using System.Net.Http;
using System.Numerics;

public class WebApiTests
{
    private static readonly Uri urlEndpoint = new("http://localhost:5124/");

    [Fact]
    public async Task TestEndToEndAddRemoveAndRetrieveToDoItems()
    {
        // Get current todo items.
        var toDoItems = await GetToDoItems();
        var toDoCount = toDoItems.Count;

        // Add two new items and store returned item ids.
        var newToDoId1 = await AddNewToDoItem("Test Title 1", "Test Contents 1");
        await AddNewToDoItem("Test Title 2", "Test Contents 2");
        await AddNewToDoItem("Test Title 3", "Test Contents 3");
        await AddNewToDoItem("Test Title 4", "Test Contents 4");
        await AddNewToDoItem("Test Title 5", "Test Contents 5");

        // Get current todo items and confirm two exist.
        toDoItems = await GetToDoItems();
        Assert.Equal(toDoCount + 5, toDoItems.Count);

        // Remove one item.
        var updatedToDoList = await RemoveToDoItem(newToDoId1);
        Assert.Equal(4, updatedToDoList.Count);

        // Get current todo items and confirm only one exists.
        toDoItems = await GetToDoItems();
        Assert.Equal(toDoCount + 4, toDoItems.Count);
    }

    [Fact]
    public async Task TestAddInvalidToDoItem()
    {
        // Assemble
        var urlTarget = $"{urlEndpoint}ToDoItems";
        using var client = new HttpClient();
        client.BaseAddress = urlEndpoint;
        var newToDoItem = new NewToDo
        {
            Title = string.Empty,
            Contents = "Test Contents",
            Priority = Domain.Enums.Priority.High,
            CompletionDate = DateTime.Now.AddDays(1)
        };
        var newToDoItemString = new StringContent(JsonConvert.SerializeObject(newToDoItem), System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync(urlTarget, newToDoItemString);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    private async Task<List<ToDo>> GetToDoItems()
    {
        // Assemble
        var urlTarget = $"{urlEndpoint}ToDoItems";

        // Act
        using var client = new HttpClient();
        client.BaseAddress = urlEndpoint;
        var response = await client.GetAsync(urlTarget);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        var result = await response.Content.ReadAsStringAsync();
        var toDoItems = JsonConvert.DeserializeObject<List<ToDo>>(result);
        Assert.NotNull(toDoItems);
        return toDoItems;
    }

    private async Task<int> AddNewToDoItem(string title, string contents)
    {
        // Assemble
        var urlTarget = $"{urlEndpoint}ToDoItems";
        using var client = new HttpClient();
        client.BaseAddress = urlEndpoint;
        var newToDoItem = new NewToDo
        {
            Title = title,
            Contents = contents,
            Priority = Domain.Enums.Priority.High,
            CompletionDate = DateTime.Now.AddDays(1)
        };
        var newToDoItemString = new StringContent(JsonConvert.SerializeObject(newToDoItem), System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync(urlTarget, newToDoItemString);
        var result = await response.Content.ReadAsStringAsync();
        var newToDoId = int.Parse(result);

        // Assert
        response.EnsureSuccessStatusCode();
        return newToDoId;
    }

    private async Task<List<ToDo>> RemoveToDoItem(int toDoId)
    {
        // Assemble
        var urlTarget = $"{urlEndpoint}ToDoItems/{toDoId}";
        using var client = new HttpClient();
        client.BaseAddress = urlEndpoint;

        // Act
        var response = await client.DeleteAsync(urlTarget);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        var result = await response.Content.ReadAsStringAsync();
        var toDoItems = JsonConvert.DeserializeObject<List<ToDo>>(result);
        Assert.NotNull(toDoItems);
        return toDoItems;
    }
}
