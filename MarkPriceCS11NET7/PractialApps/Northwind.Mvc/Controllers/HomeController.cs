using Microsoft.AspNetCore.Mvc;
using Northwind.Mvc.Models;
using System.Diagnostics;
using Packt.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Northwind.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly NorthwindContext db;
    private readonly IHttpClientFactory clientFactory;//para consumir rest API

    public HomeController
        (ILogger<HomeController> logger, NorthwindContext injectedContext, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        db = injectedContext;
        clientFactory = httpClientFactory;
    }






    [ResponseCache(Duration = 10/*seconds*/,
        Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Index()
    {
        //this is a record type variable
        HomeIndexViewModel model = new
        (
            VisitorCount: Random.Shared.Next(1, 1001),
            Categories: await db.Categories.ToListAsync(),
            Products: await db.Products.ToListAsync()
        );

        try
        {
            HttpClient client = clientFactory.CreateClient(
            name: "Minimal.WebApi");
            HttpRequestMessage request = new(
            method: HttpMethod.Get, requestUri: "weatherforecast");
            HttpResponseMessage response = await client.SendAsync(request);
            ViewData["weather"] = await response.Content
            .ReadFromJsonAsync<WeatherForecast[]>();
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"The Minimal.WebApi service is not responding. Exception:{ex.Message}");
            ViewData["weather"] = Enumerable.Empty<WeatherForecast>().ToArray();
        }

        return View(model);
    }




    //calling the Northwind.WebApi API to get a list of customers by country or general.
    public async Task<IActionResult> Customers(string country)
    {
        string uri;
        if(string.IsNullOrEmpty(country))
        {
            ViewData["Title"] = "Of All Countries Of The World";
            uri = "/api/customers";
        }
        else
        {
            ViewData["Title"] = $"Customers from {country}";
            uri = $"/api/customers/?country={country}";
        }


        HttpClient client = clientFactory.CreateClient(
            name:"Northwind.WebApi");

        HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);
        //HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: uri);

        HttpResponseMessage response = await client.SendAsync(request);
        //HttpResponseMessage response = await client.SendAsync(request);

        IEnumerable<Customer>? model = await response.Content
            .ReadFromJsonAsync<IEnumerable<Customer>>();

        return View(model);
    }


    public IActionResult ProductsThatCostMoreThan(int? price)
    {
        if (price is null)
            return BadRequest("No 'price' provided");

        IEnumerable<Product> queryResults = db.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .Where(p => p.UnitPrice > price);

        if(!queryResults.Any())
            return NotFound($"Not producto cost more than {price:C}");

        ViewData["MaxPrice"] = price.Value.ToString("C");

        return View(queryResults);
    }


    

    [Route("private")]
    [Authorize(Roles = "Administrators")]
    public IActionResult Privacy()
    {
        ViewData["0"]="Hola from privacy";
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    public async Task<IActionResult> ProductDetail(int? id, string alertstyle = "success")
    {
        ViewData["alertstyle"] = alertstyle;
        if (!id.HasValue)
        {
            return BadRequest("You must pass a product ID in the route, for example: /home/ProductDetail/21");
        }
        Product? model = await db.Products.SingleOrDefaultAsync(p => p.ProductId == id);

        if (model is null)
            return NotFound($"ProductId {id} not found, You must pass a product ID in the route, for example: /home/ProductDetail/21");

        return View(model);
    }

    public IActionResult ModelBinding()
    {
        ViewBag.Message = "fist time";
        return View();
    }

    [HttpPost]
    public IActionResult ModelBinding(Thing thing)
    {
        HomeModelBindingViewModel model = new(
        Thing: thing,
        HasErrors: !ModelState.IsValid,
        ValidationErrors: ModelState.Values.SelectMany(state => state.Errors)
        .Select(error => error.ErrorMessage));

        return View(model);
    }
}
