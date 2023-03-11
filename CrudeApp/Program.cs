using CrudeApp.Data;
using CrudeApp.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add database configuration
//var server = builder.Configuration["DB_HOST"] ?? "";
//var port = builder.Configuration["DB_PORT"] ?? "";
//var user = builder.Configuration["DB_USER"] ?? "";
//var password = builder.Configuration["DB_SA_PASSWORD"] ?? "";
//var database = builder.Configuration["DB_NAME"] ?? "";
var connectionString = "Server=sql.bsite.net\\MSSQL2016;database=shyam123_; User ID=shyam123_; Password=shyam123;TrustServerCertificate=True;";
//var connectionString = "Data Source=localhost,1433;Initial Catalog=crud; User ID=sa; Password=Password@1234;TrustServerCertificate=True;";
//var connectionString = "Server=localhost;database=crude;trusted_connection=true; TrustServerCertificate=True;Integrated Security=true;";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();

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
