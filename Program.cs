using ConfigurationService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing; // Обеспечивает MapControllers и UseRouting
using Npgsql.EntityFrameworkCore.PostgreSQL; // Может потребоваться для UseNpgsql

var builder = WebApplication.CreateBuilder(args);

// ===================================================
// 1. КОНФИГУРАЦИЯ СЕРВИСОВ (builder.Services)
// ===================================================

// Подключение и регистрация DbContext
var connectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection"); 

// 💡 Наше подключение к PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(connectionString));

// Добавление контроллеров
builder.Services.AddControllers();

// Добавление Swagger/OpenAPI для документации API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// ===================================================
// 2. КОНФИГУРАЦИЯ ПРИЛОЖЕНИЯ (app.Use...)
// ===================================================

// Swagger UI доступен только в режиме разработки (Development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 1. Сначала перенаправление на HTTPS (безопасность)
app.UseHttpsRedirection(); 

// 2. Авторизация (проверка прав доступа)
app.UseAuthorization(); 

// 3. КОНЕЦ КОНВЕЙЕРА: Запуск контроллеров
app.MapControllers();

// Запуск веб-сервера
app.Run();