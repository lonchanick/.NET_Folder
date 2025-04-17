using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

//namespace Northwind.Razor.Employees.MyFeature.Pages;
namespace PacktFeatures.Pages;

public class EmployeesPageModel : PageModel
{
    public NorthwindContext db;
    public Employee[]? Employees { get; set; }
    public EmployeesPageModel(NorthwindContext injectedDB)
    {
        db = injectedDB;
    }

    public void OnGet()
    {
        ViewData["Title"]= "Northwind B2B - Employees";
        Employees = db.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ToArray();
    }
}
