using Frigy.Server.Data;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
{
    services.AddData(builder.Configuration);
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();
}

app.Run();