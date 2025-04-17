using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace Northwind.Web.Pages
{
    public class SupplierAddModel : PageModel
    {
        private readonly NorthwindContext db;

        public SupplierAddModel(NorthwindContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Supplier Supplier {get; set;}

        public IActionResult OnPost()
        {
            if((Supplier is not null) && (ModelState.IsValid))
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }else
            {
                return Page();
            }
        }
    }
}
