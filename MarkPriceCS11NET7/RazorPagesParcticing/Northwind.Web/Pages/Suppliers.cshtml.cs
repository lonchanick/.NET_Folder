using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace Northwind.Web.Pages;

public class SuppliersModel : PageModel
{
    private NorthwindContext db;

    public SuppliersModel(NorthwindContext dbInjected){ db = dbInjected; }

    public IEnumerable<Supplier>? Suppliers { get; set; }
    public void OnGet()
    {
        ViewData["Title"] = "Suppliers List";
        //Suppliers = db.Suppliers;
        Suppliers = db.Suppliers.OrderBy(c => c.Country).ThenBy(c => c.CompanyName);
    }

    
}
