using Bakery.Data;
using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly BakeryContext _bakeryContext;

    public List<Product> Products { get; set; } = new();

    public IndexModel(ILogger<IndexModel> logger, BakeryContext bakeryContext)
    {
        _bakeryContext = bakeryContext;
        _logger = logger;
    }

    public async Task OnGetAsync() =>
        Products = await _bakeryContext.Products.ToListAsync();

}
