using System.Text.Json.Serialization;
using Core.Interfaces;
using Infrastructure.Data.Stub;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddHealthChecks();

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });;
    
builder.Services.AddHttpClient();

builder.Services.AddCoreServices();
builder.Services.AddInfrastructureServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RouteOptions>(options =>
{
   options.LowercaseUrls = true;
});

var app = builder.Build();

app.MapHealthChecks("/healthz");


// Configure the HTTP request pipeline.

// Disabled for demo purposes
// if (app.Environment.IsDevelopment())
// {
    // Load StubData
    using (var scope = app.Services.CreateScope())
    {
        var dataLoader = scope.ServiceProvider.GetRequiredService<IDataStore>();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
