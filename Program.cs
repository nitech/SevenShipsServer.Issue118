using CommunityToolkit.Datasync.Server;
using LiteDB;
using CommunityToolkit.Datasync.Server.NSwag;
using NSwag;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatasyncServices();
builder.Services.AddControllers();

builder.Services.AddOpenApiDocument(options =>
{
    options.AddDatasyncProcessor();
    options.PostProcess = document =>
    {
        document.Info = new OpenApiInfo
        {
            Version = "v1",
            Title = "SevenShipsServer",
            Description = "Server for SevenShips App Suite"
        };
    };
});

var connectionString = builder.Configuration.GetValue<string>("LiteDb:ConnectionString");
builder.Services.AddSingleton<LiteDatabase>(new LiteDatabase(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
