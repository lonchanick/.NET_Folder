using Packt.Shared;//para injectar la classe AddNorthwindContext() que es las que tiene el servicio de 
//EF implementado

var builder = WebApplication.CreateBuilder(args);//esto crea un web host con configuracion default

builder.Services.AddRazorPages();//antes del build

//agregating entity framework service
builder.Services.AddNorthwindContext();

var app = builder.Build();//esto instancia un web host, usa la configuracion default


if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseExceptionHandler("/Error");
}

app.UseDefaultFiles();//en este
app.UseStaticFiles();//orden
app.UseHttpsRedirection();
app.MapRazorPages();//enable razor pages, hace que mapee y encuentre las pages

app.MapGet("/hello", () => "Hello World!");

app.Run();//blocking call que no termina hasta el metodo Main escondido retorne, o sea hasta que el server (host) termine de ejecutarse

WriteLine("I haven't add anything yet");
