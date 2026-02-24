using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Sistema Escolar",
        Version = "v1",
        Description = "Backend de notificações escolares"
    });
});


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Escolar v1");
        c.RoutePrefix = string.Empty; // Swagger abre direto na raiz (http://localhost:5279)
});


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();