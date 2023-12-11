var builder = WebApplication.CreateBuilder(args);

// Bổ sung dịch vụ MVC trên container của web server
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình mô hình Routing cho ứng dụng hoạt động
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Create}/{id?}");

app.Run();
