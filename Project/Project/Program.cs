using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders().AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "trang-chu",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "trang-chu",
    pattern: "trang-chu/{area=Customer}/{controller=Home}/{action=Index}/{id?}",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "about",
    pattern: "about/{area=Customer}/{controller=Nhom}/{action=Index}/{id?}",
    defaults: new { controller = "Nhom", action = "Index" });
app.MapControllerRoute(
    name: "service",
    pattern: "service/{area=Customer}/{controller=Nhom}/{action=Index3}/{id?}",
    defaults: new { controller = "Nhom", action = "Index3" });
app.MapControllerRoute(
    name: "contact",
    pattern: "contact/{area=Customer}/{controller=Nhom}/{action=Index2}/{id?}",
    defaults: new { controller = "Nhom", action = "Index2" });
app.MapControllerRoute(
    name: "sales",
    pattern: "sales/{area=Customer}/{controller=Nhom}/{action=Index1}/{id?}",
    defaults: new { controller = "Nhom", action = "Index1" });


app.MapRazorPages();

app.Run();
