.NET application for solar system data.

Change logs
1.Upgraded the existing application from .NET 5 to .NET 10 while keeping the original project structure.
2.Added Bearer token authentication.
3.Replaced .Result with async/await asynchronous operations to avoid blocking the thread during API calls.
4.Added average moon temperature and gravity calculations in the Planet class to keep the calculation logic separate from the output service.
5.Added console output to display planets having one or more moons.
6.Use the appsetting.local.json or add the new api key in the appsetting to get the result.