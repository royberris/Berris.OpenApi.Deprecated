# OpenApi Deprecated

This package provides a simple way to deprecate your API endpoints using the `Microsoft.AspNetCore.OpenApi` OpenAPI generator. Which is not supported out of the box by the OpenAPI generator.

## Installation

Using the .NET CLI:

```bash
dotnet add package Berris.OpenApi.Deprecated
```

## Usage

Add the operation transformer to your OpenAPI configuration.

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(i =>
{
    i.AddDeprecatedOperationTransformer();
});
```

Decorate your minimal api endpoints with the `IsDeprecated` extension method.

```csharp
app.MapGet("/weatherreport", () => "Hello World!")
    .WithName("GetWeatherReport")
    .IsDeprecated();
```

See the [sample project](./MinimalApiExample/Program.cs) for a complete example.

## How it works

This will add the `deprecated` field to the OpenAPI document for given operation.

```
"/weatherreport": {
    "get": {
      "tags": [
        "MinimalApiExample"
      ],
      "operationId": "GetWeatherReport",
      "responses": {
        "200": {
          "description": "OK"
        }
      },
      "deprecated": true // <--- This field is added
    }
  }
```

And the operation will be marked as deprecated in the OpenAPI viewer of choice.

![example with Swagger UI](example.png)