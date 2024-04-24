using FastEndpoints;
using FastEndpoints.Swagger;
using Gallery.API;
using Gallery.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

Console.WriteLine(Guid.NewGuid());

app.Run();
