
//The first section imports some namespaces
using FluentAssertions.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Northwind.Mvc.Data;
using Packt.Shared;
using System.Net.Http.Headers; // AddNorthwindContext extension method

//The second section creates and configures a web host builder that does the following:
// Section 2 - configure the host web server including services
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddNorthwindContext();//invoke extession method to inject dbcontext to container


builder.Services.AddHttpClient(name: "Northwind.WebApi",
configureClient: options =>
{
options.BaseAddress = new Uri("https://localhost:5002/");
options.DefaultRequestHeaders.Accept.Add(
new MediaTypeWithQualityHeaderValue(mediaType: "application/json", quality: 1.0));
});



//output catching endpoints
builder.Services.AddOutputCache(options => 
{
    options.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(10);
    options.AddPolicy("views", p => p.SetVaryByQuery("alertstyle"));
});


builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#region Authentication
//este codigo es generado cuando recien se crea el proyecto
builder.Services.AddDefaultIdentity<IdentityUser>
    (options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()//authentication
    .AddEntityFrameworkStores<ApplicationDbContext>();

#endregion

builder.Services.AddControllersWithViews();

#region setting up httpclient to call weatherforecast minimalApi

builder.Services.AddHttpClient(name: "Minimal.WebApi",
configureClient: options =>
{
    options.BaseAddress = new Uri("https://localhost:5003/");
    options.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue(
    "application/json", 1.0));
});

#endregion


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

//output cached
app.UseOutputCache();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .CacheOutput("views");//output cached (views)

app.MapRazorPages();

//output cached
app.MapGet("/notcached", () => DateTime.Now.ToString());
app.MapGet("/cached", () => DateTime.Now.ToString()).CacheOutput();


app.Run();
