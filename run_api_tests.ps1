dotnet clean
dotnet build

# Run server in background
Start-Job -Name "ToDoServer" -ScriptBlock { dotnet run --project ./Ianf.Global360ToDo.WebAPI/Ianf.Global360ToDo.WebAPI.csproj }
Start-Sleep 8 # Crude, but works for now

# Run api tests
dotnet test ./Ianf.Global360ToDo.WebAPI.Tests/Ianf.Global360ToDo.WebAPI.Tests.csproj

# Close down server
Stop-Job ToDoServer
Remove-Job ToDoServer
