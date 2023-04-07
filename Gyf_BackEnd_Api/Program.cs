
using FluentValidation.AspNetCore;
using FluentValidation;
using GyfBackendApiPersistencia.SISTEMAS;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Debugging;
using Serilog.Events;
using Serilog.Sinks.Grafana.Loki;
using static GyfBackendApiAplicacion.System.Qry_System_Add;
using GyfBackendApiAplicacion.System;
using Gyf_BackEnd_Api.Middleware;

SelfLog.Enable(Console.Error);

var builder = WebApplication.CreateBuilder(args);

var credentials = new GrafanaLokiCredentials()
{
    User = "lramirez",
    Password = "xLNAlem454"
};

var labels = new List<LokiLabel>()
{
    new LokiLabel { Key = "User", Value = credentials.User },
    new LokiLabel { Key = "Gyf", Value = "GYF_Api_System" }
};
var lokiCredentials = new LokiCredentials
{
    Login = credentials.User,
    Password = credentials.Password
};

builder.Logging.ClearProviders();

builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));
builder.Services.AddSingleton<Serilog.ILogger>(new LoggerConfiguration()
    .WriteTo.GrafanaLoki(
        "http://20.127.17.88:3100",
        labels: labels,
        credentials: lokiCredentials
    )
    .CreateLogger());




//.WriteTo.GrafanaLoki("http://20.127.17.88:3100")
/*
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

*/



// Add services to the container.

builder.Services.AddMediatR(typeof(Qry_System_List).Assembly, typeof(Program).Assembly);
builder.Services.AddMediatR(typeof(Qry_System).Assembly, typeof(Program).Assembly);


builder.Services.AddScoped<TraceMiddleware>();
builder.Services.AddScoped<IGyf_Sistemas, Gyf_SistemasRepository>();



builder.Services.AddControllers();

// Configuracion de FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(ExecuteAdd));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(o => o.AddPolicy("corsApp", builder => {
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));









var app = builder.Build();
app.UseCors("corsApp");


// Configure the HTTP request pipeline.
app.UseMiddleware<ManejadorErrorMiddleware>();
app.UseMiddleware<TraceMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
