using Assessment.Task1.Models;
using Assessment.Task1.Bc;
using Assessment.Task1.Service;
using Assessment.Task1.Dao;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddSingleton<IUserDao, UserDao>();
builder.Services.AddScoped<IFileHandler, FileHandler>();
builder.Services.AddScoped<IEmployeeDao, EmployeeDao>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseSession();
app.UseHttpsRedirection();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
