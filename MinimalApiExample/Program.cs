using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(i =>
{
    i.AddDeprecatedOperationTransformer();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
    
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () => "Hello World!")
    .WithName("GetWeatherForecast");

app.MapGet("/weatherreport", () => "Hello World!")
    .WithName("GetWeatherReport")
    .IsDeprecated();

app.Run();
