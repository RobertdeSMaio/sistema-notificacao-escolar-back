using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using SistemaEscolar.Data;
using SistemaEscolar.Repositories;
using SistemaEscolar.Services;
using SistemaEscolar.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);


<<<<<<< HEAD
=======
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
>>>>>>> 11f46fe328f8d5669174350f7a156edc11c986c2
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<UserService>();


builder.Services.AddScoped<AuthService>();

var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "ChaveSuperSecretaDe32CaracteresNoMinimo");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


<<<<<<< HEAD

builder.Services.AddControllers();


=======
builder.Services.AddControllers();
>>>>>>> 11f46fe328f8d5669174350f7a156edc11c986c2
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
builder.Services.AddCors(options => {
    options.AddPolicy("EscolaAppPolicy", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{

=======
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
>>>>>>> 11f46fe328f8d5669174350f7a156edc11c986c2
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

<<<<<<< HEAD
app.UseCors("EscolaAppPolicy");
=======
app.UseAuthentication(); 
app.UseAuthorization();
>>>>>>> 11f46fe328f8d5669174350f7a156edc11c986c2

app.MapControllers();

app.Run();