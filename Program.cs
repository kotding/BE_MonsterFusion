using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using MonsterFusion_BE;
using MonsterFusion_BE.Features.EventConfig;
using MonsterFusion_BE.Features.EventConfig.AviatorEvent.Service;
using MonsterFusion_BE.Features.EventConfig.AviatorEvent.Service.BGService;
using MonsterFusion_BE.Features.EventConfig.ChristmasEvent.Service;

var builder = WebApplication.CreateBuilder(args);
Env.Load();
var connectString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option => option.UseNpgsql(connectString));
builder.Services.AddDbContext<IAllEventRepository,AllEventRepository>(options => options.UseNpgsql(connectString));
builder.Services.AddScoped<AviatorEventService>();
builder.Services.AddScoped<ChristmasEventService>();
builder.Services.AddScoped<IServiceProvider, ServiceProvider>();

builder.Services.AddHostedService<ResetAviatorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
