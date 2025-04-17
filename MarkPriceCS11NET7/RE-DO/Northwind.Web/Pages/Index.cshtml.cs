
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;


namespace Northwind.Web.Pages;

public class IndexModel : PageModel
{
    public IQueryable Employees { get; set; }
    public string? DayName;
    private readonly NorthwindContext db;

    public IndexModel(NorthwindContext injected)
    {
        db = injected;
    }

    public void OnGet()
    {
        Employees = db.Employees.OrderBy(e => e.FirstName);
    }
}