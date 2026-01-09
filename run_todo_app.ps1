dotnet clean
dotnet build

# Run server in background
dotnet run --project ./Ianf.Global360ToDo.WebAPI/Ianf.Global360ToDo.WebAPI.csproj &
Start-Sleep 3

# Run angular app
