// Adicione no topo do Program.cs
using SistemaEscolar.Models.Interfaces;
using SistemaEscolar.Repositories;
using SistemaEscolar.Services;
using SistemaEscolar.Data;

// ... dentro do builder:
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();