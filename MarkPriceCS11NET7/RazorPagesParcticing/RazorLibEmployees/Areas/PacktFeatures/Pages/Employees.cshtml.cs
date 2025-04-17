using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace RazorLibEmployees.MyFeature.Pages;

public class EmployeesModel : PageModel
{
    private readonly NorthwindContext db;

    public EmployeesModel(NorthwindContext db)
    {
        this.db = db;
    }

    public Employee[] Employees { get; set; } = null!;
    public void OnGet()
    {
        Employees = db.Employees.OrderBy(e => e.LastName).ToArray();
    }
}
