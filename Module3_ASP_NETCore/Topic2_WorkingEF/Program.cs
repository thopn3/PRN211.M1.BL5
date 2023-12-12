using Microsoft.EntityFrameworkCore;
using Topic2_WorkingEF.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Cấu hình đọc chuỗi kết nối từ appsettings.json
builder.Services.AddDbContext<PE_PRN_Fall2023B1Context>(
        opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PRN"))
    );

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
