param (
    [int]$SleepTime = 10 
)

dotnet clean
dotnet build

# Kill any remaining servers for this app that may still be around
Stop-Job ToDoServer
Remove-Job ToDoServer

# Run server in background
Start-Job -Name "ToDoServer" -ScriptBlock { dotnet run --project ./Ianf.Global360ToDo.WebAPI/Ianf.Global360ToDo.WebAPI.csproj }
Write-Host "Sleeping for $SleepTime seconds"
Start-Sleep $SleepTime # Crude, but works for now
Write-Host "Slept for $SleepTime seconds"

# Run angular app
Set-Location ./ToDoClient
npm install
ng serve