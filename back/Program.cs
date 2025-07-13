using Microsoft.EntityFrameworkCore;
using encurtador_url.back.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy => policy
            .WithOrigins("http://localhost:5173") // frontend Vite
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Ativa Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ATIVA CORS AQUI - antes do UseAuthorization
app.UseCors("AllowLocalhost");

// NÃO usa https redirection se está testando em http
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
