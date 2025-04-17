
using Microsoft.AspNetCore.Server.Kestrel.Core;//HttpProtocols - this is for implement http/3
using Packt.Shared;
//An ASP.NET Core project is like a top-level console app, with a hidden <Main>$ method
//as its entry point that has an argument passed using the name args.

var builder = WebApplication.CreateBuilder(args);
//before the statement that builds the app,
builder.Services.AddRazorPages();//me
builder.Services.AddNorthwindContext();//me
builder.Services.AddRequestDecompression();//me pag. 596


//enabling HTTP /1 /2 and /3   pag. 597
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
        listenOptions.UseHttps(); // HTTP/3 requires secure connections
    });
});



var app = builder.Build();



if (!app.Environment.IsDevelopment())//me
{
    app.UseHsts();
}

app.UseHttpsRedirection();//me
app.UseRequestDecompression();//me pag 596


app.Use(async (HttpContext context, Func<Task> next) =>
{
    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;
    if (rep is not null)
    {
        WriteLine($"Endpoint name: {rep.DisplayName}");
        WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");
    }
    if (context.Request.Path == "/bonjour")
    {
        // in the case of a match on URL path, this becomes a terminating
        // delegate that returns so does not call the next delegate
        await context.Response.WriteAsync("Bonjour Monde!");
        return;
    }
    // we could modify the request before calling the next delegate
    await next();
    // we could modify the response after calling the next delegate
});





//enable static files and default files. Also, modify the statement that maps a GET request to return 
//the Hello World! plain text response to only respond to the URL path /hello, as shown highlighted
//in the following code
app.UseDefaultFiles();//The call to UseDefaultFiles must come before the call to UseStaticFiles
app.UseStaticFiles();

app.MapRazorPages();//me
app.MapGet("/hello", () => "Hello World!");//edited by me
app.Run();

WriteLine("This is executed after server has stoped");
