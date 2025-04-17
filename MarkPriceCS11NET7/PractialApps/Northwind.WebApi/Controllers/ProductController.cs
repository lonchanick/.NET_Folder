using Microsoft.AspNetCore.Mvc;
using Northwind.WebApi.Repositories;
using Packt.Shared;

namespace Northwind.WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ICustomerRepository repo;

    public ProductController(ICustomerRepository repoInjected)
    {
        repo = repoInjected;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
    public async Task<IEnumerable<Product>> Index()
    {
        var products = await repo.GetProductsAsync();
        return products;
    }

    [HttpPost]
    public async Task AddProd(Product prod)
    {
        var responseNumber =await repo.AddProductAsync(prod);
        await Out.WriteLineAsync($"{nameof(responseNumber)} is: {responseNumber}");
    }
}
