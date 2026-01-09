# global360challenge

Code Challenge for Global 360

- To run
  - Start the web service in Ianf.Global360challenge.WebAPI. dotnet run
  - Start the angular app.

- For brevity
  - avoided CORS or HTTPS interaction. Normally would be handled at Web API layer.
  - avoided any auth interaction. Normally would be handled at Web API layer.

- More complex than required to demonstrate patterns. In something this small would not:
  - Test the service layer with a Moq repository as repository is in-memory so no need to mock out an external-process call.
