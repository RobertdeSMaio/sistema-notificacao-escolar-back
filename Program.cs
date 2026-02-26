using System;
using Microsoft.EntityFrameworkCore;
using SistemaNotificacaoEscolarBack.Data.Context;
using SistemaNotificacaoEscolarBack.Models.Interfaces.IUserService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseInMemoryDatabase("EscolarDb"));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("https://sistema-escolar-gules.vercel.app")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new global::Microsoft.OpenApi.OpenApiInfo
    {
        Title = "API Sistema Escolar",
        Version = "v1",
        Description = "Backend de notificações escolares"
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Escolar v1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();