using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Packt.Shared;

namespace Northwind.Web.Pages;

public class SuppliersModel : PageModel
{
    protected NorthwindContext? db;
    
    [BindProperty]
    public Supplier _Supplier { get; set; }
    public IEnumerable<Supplier> Suppliers { get; set; }

    public SuppliersModel(NorthwindContext InjectedContext)
    {
        db = InjectedContext;
    }

    public void OnGet()
    {
        ViewData["Title"] = "Suppliers-list";
        Suppliers = db.Suppliers.OrderBy(o => o.Country).ThenBy(s => s.CompanyName);
    }

    public IActionResult OnPost()
    {
        if((_Supplier is not null) && ModelState.IsValid)
        {
            db.Suppliers.Add(_Supplier);
            db.SaveChanges();
            return RedirectToPage("/suppliers");
        }
        else
        {
            return Page();
        }

    }
}
