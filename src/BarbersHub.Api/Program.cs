using Serilog;
using Newtonsoft.Json; 
using BarbersHub.Api.Models;
using BarbersHub.Api.Extensions;
using BarbersHub.Service.Helpers;
using BarbersHub.Api.MiddleWares;
using BarbersHub.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomService();

// ==========> Logger 
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

/////// Configuration Api Url
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(
                                        new ConfigurationApiUrlName()));
});

//////// Fix the Cycle
builder.Services.AddControllers()
     .AddNewtonsoftJson(options =>
     {
         options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
     });

// ==========> Db connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ==========> EnvironmentHelper
EnvironmentHelper.WebRootPath = Path.GetFullPath("wwwroot");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseStaticFiles();
app.MapControllers();

app.Run();
