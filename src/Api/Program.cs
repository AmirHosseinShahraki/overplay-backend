using Api;
using Api.Infrastructure;
using Infrastructure;
using Application;
using dotenv.net;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    DotEnv.Load();
}

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApiServices();
builder.Services.ConfigureMapster();
builder.Services.ConfigureValidators();
builder.Services.ConfigureCors();

builder.Services.AddEndpoints();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

WebApplication app = builder.Build();

app.UseExceptionHandler(options => { });
app.UseCors("AllowOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHealthChecks("/health");

app.MapEndpoints();

app.Run();