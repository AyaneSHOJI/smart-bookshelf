var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add MVC controllers
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            if (builder.Environment.IsDevelopment())
            {
                // In development we allow any origin to avoid localhost/port mismatches.
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            }
            else
            {
                // In production, be strict about allowed origins.
                policy.WithOrigins(
                        "https://your-production-domain.com"
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }
        });
});

builder.WebHost.UseUrls("https://localhost:7094","http://localhost:5278");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

// Map attribute-routed controllers
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
