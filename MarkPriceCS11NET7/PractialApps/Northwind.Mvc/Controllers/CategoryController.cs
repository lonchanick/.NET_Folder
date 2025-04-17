using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Mvc.Models;
using Packt.Shared;

namespace Northwind.Mvc.Controllers;

public class CategoryController : Controller
{
    private readonly NorthwindContext _db;
    public CategoryController(NorthwindContext DbContextInjected)
    {
        _db = DbContextInjected;
    }
    public async Task<IActionResult> Index()
    {
        IList<Category> categories = await  _db.Categories.ToListAsync();
        return View(categories);
    }

    public async Task<IActionResult> CategoryDetails(int? id)
    {
        if (id is null)
            return NotFound("No Id provided!");

        //Category categoryC = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
        //int quantityC = _db.Products.Where(p => p.CategoryId == id).ToList().Count();
        var categoryWithProductCount = await _db.Categories
                .Where(c => c.CategoryId == id)
                .Select(c => new
                {
                    Category = c,
                    ProductCount = c.Products.Count()
                })
                .FirstOrDefaultAsync();

        if (categoryWithProductCount is null)
            return BadRequest("Id does not exist");

        CategoryAndQuantity cAdnQ = new()
        {
            category = categoryWithProductCount.Category,
            Quantity = categoryWithProductCount.ProductCount
        };

        if (categoryWithProductCount is null)
            return NotFound("It does not exist the category");
         
        return View(cAdnQ);

    }
}

