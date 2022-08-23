build:
	dotnet build .\Ordering.sln

run: build
	dotnet run --project .\src\Ordering\Ordering.API\Ordering.API.csproj

format:
	dotnet-format .\Ordering.sln