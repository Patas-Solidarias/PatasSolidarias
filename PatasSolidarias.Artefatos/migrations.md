## Initial Create
```bash
dotnet ef migrations add InitialCreate --verbose --project PatasSolidarias.Infra --startup-project PatasSolidarias.Api
dotnet ef database update --project PatasSolidarias.Infra --startup-project PatasSolidarias.Api
```