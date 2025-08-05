using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Logging: Set up Serilog
builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day));

// 🔹 Database: Configure EF Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Swagger: API docs + XML comments
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// 🔹 Dependency Injection: Register services and repositories
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

// 🔹 Controllers
builder.Services.AddControllers();

var app = builder.Build();

// 🔹 Middleware Pipeline

// Use Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect root to Swagger UI
app.MapGet("/", () => Results.Redirect("/swagger"));

// Serilog request logging
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
