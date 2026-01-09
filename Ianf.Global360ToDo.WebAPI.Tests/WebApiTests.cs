namespace Ianf.Global360ToDo.WebAPI.Tests;

using Ianf.Global360ToDo.Domain;
using Newtonsoft.Json;
using System.Net.Http;

public class WebApiTests
{
    private static readonly Uri urlEndpoint = new("http://localhost:5124/");

    [Fact]
    public async Task TestEndToEndAddRemoveAndRetrieveToDoItems()
    {
        var toDoItems = await GetToDoItems();
        var latestItemId = toDoItems.Count;
        await AddNewToDoItems(latestItemId);
    }

    private async Task<List<ToDo>> GetToDoItems()
    {
        // Assemble
        var urlTarget = $"{urlEndpoint}ToDoItems";

        // Act
        using var client = new HttpClient();
        client.BaseAddress = urlEndpoint;
        var response = await client.GetAsync(urlTarget);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        var toDoItems = JsonConvert.DeserializeObject<List<ToDo>>(result);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        return toDoItems;
    }

    private async Task AddNewToDoItems(int latestItemId)
    {
        // Assemble
        var urlTarget = $"{urlEndpoint}ToDoItems";
        using var client = new HttpClient();
        client.BaseAddress = urlEndpoint;
        var newToDoItem = new NewToDo
        {
            Title = "Test Title",
            Contents = "Test Contents",
            Priority = Domain.Enums.Priority.High,
            CompletionDate = DateTime.Now
        };
        var newToDoItemString = new StringContent(JsonConvert.SerializeObject(newToDoItem), System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync(urlTarget, newToDoItemString);
        var result = await response.Content.ReadAsStringAsync();
        var newToDoId = JsonConvert.DeserializeObject<ToDoId>(result);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(latestItemId + 1, newToDoId.Id);
    }
}
