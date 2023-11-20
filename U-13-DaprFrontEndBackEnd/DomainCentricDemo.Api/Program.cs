using System.Diagnostics;
using DomainCentricDemo.Api.Data.DataInitializer;
using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Implentation;
using DomainCentricDemo.Infrastructure;
using DomainCentricDemo.Infrastructure.Queries;
using DomainCentricDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var daprHttpPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "32000";
var daprGrpcPort = Environment.GetEnvironmentVariable("DAPR_GRPC_PORT") ?? "3800";
builder.Services.AddDaprClient(config => config
    .UseHttpEndpoint($"http://localhost:{daprHttpPort}")
    .UseGrpcEndpoint($"http://localhost:{daprGrpcPort}"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddDapr();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookQuery, BookQuery>();
builder.Services.AddScoped<IBookCommand, BookCommand>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BookConnectionString"), opt =>
        {
            opt.MigrationsAssembly
                ("DomainCentricDemo.Infrastructure");
        }));
// Add-Migration Init -Project DomainCentricDemo.InfraStructure -Context BookContext
// Update-Database -Context BookContext

var app = builder.Build();

SeedBooks();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCloudEvents();
app.MapSubscribeHandler();
app.MapControllers();


app.Run();

void SeedBooks()
{
    using var scope = app.Services.CreateScope();
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var db = serviceProvider.GetRequiredService<BookContext>();
        db.Database.EnsureCreated();
        AuthorAndBookDataInitializer.SeedData(db);
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
    }
}