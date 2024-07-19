using Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureInfrastructureLayer(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();