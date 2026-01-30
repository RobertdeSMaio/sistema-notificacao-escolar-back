using Microsoft.EntityFrameworkCore;
using sistema_notificacao_escolar_back.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Banco de Dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Adicione suporte aos Controllers (Essencial para ver suas rotas!)
builder.Services.AddControllers();

// 3. Configuração do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// --- AQUI O APP É CONSTRUÍDO ---
var app = builder.Build();

// 4. Configuração do Pipeline (O que acontece quando o app roda)
if (app.Environment.IsDevelopment())
{
    // Ativa a interface visual do Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 5. Mapeia os Controllers para que as rotas funcionem
app.MapControllers();

app.Run();