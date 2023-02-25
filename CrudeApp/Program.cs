using CrudeApp.Data;
using CrudeApp.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add database configuration
var server = builder.Configuration["DB_HOST"] ?? "";
//var port = builder.Configuration["DatabasePort"] ?? "";
//var user = builder.Configuration["DatabaseUser"] ?? "";
var password = builder.Configuration["DB_SA_PASSWORD"] ?? "";
var database = builder.Configuration["DB_NAME"] ?? "";
var connectionString = $"Server={server}; Initial-Catalog={database};User ID=sa;Password={password}";
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddScoped<IUserServices, UserServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();
