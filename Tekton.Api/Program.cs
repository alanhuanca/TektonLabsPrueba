using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using Tekton.Api.Middleware;
using Tekton.Application;
using Tekton.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

const string logPath = "../log/serilog_example-.log";
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Prueba Técnica Tekton",
        Description = "Proyecto desarrollado para prueba técnica de la empresa Tekton",
        TermsOfService = new Uri("https://www.tektonlabs.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Alan Huanca Villaverde",
            Url = new Uri("https://www.tektonlabs.com/contact-us")
        },
        License = new OpenApiLicense
        {
            Name = "License MIT",
            Url = new Uri("https://www.tektonlabs.com/license")
        }

    });
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<TimeLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
