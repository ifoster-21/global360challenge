param (
    [int]$SleepTime = 10 
)

dotnet clean
dotnet build

# Run server in background
Start-Job -Name "ToDoServer" -ScriptBlock { dotnet run --project ./Ianf.Global360ToDo.WebAPI/Ianf.Global360ToDo.WebAPI.csproj }
Write-Host "Sleeping for $SleepTime seconds"
Start-Sleep $SleepTime # Crude, but works for now
Write-Host "Slept for $SleepTime seconds"

# Run api tests
dotnet test ./Ianf.Global360ToDo.WebAPI.Tests/Ianf.Global360ToDo.WebAPI.Tests.csproj

# Close down server
Stop-Job ToDoServer
Remove-Job ToDoServer
