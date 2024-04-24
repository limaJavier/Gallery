using FastEndpoints;
using FastEndpoints.Swagger;
using Gallery.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

Console.WriteLine(Guid.NewGuid());

app.Run();
