using Packt.Shared;

var builder = WebApplication.CreateBuilder(args);

//inject services
builder.Services.AddRazorPages();
builder.Services.AddDbContext<NorthwindContext>();//no es necesario pasar la conexion string xq ya esta en uso en sqlite


var app = builder.Build();


if(!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();


app.MapRazorPages();

app.MapGet("/hello", () => "Hello World!");

app.Run();
