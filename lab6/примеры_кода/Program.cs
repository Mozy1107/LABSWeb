using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Models;
using RazorPagesApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

// 1. Настройка Razor Pages и SignalR
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

// 2. Подключение БД
builder.Services.AddDbContext<RazorPagesAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesAppContext") 
    ?? throw new InvalidOperationException("Connection string 'RazorPagesAppContext' not found.")));

var app = builder.Build();

// 3. Инициализация данных (SeedData)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// 4. Настройка Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// 5. Регистрируем хаб чата
app.MapHub<ChatHub>("/chatHub");

app.Run();