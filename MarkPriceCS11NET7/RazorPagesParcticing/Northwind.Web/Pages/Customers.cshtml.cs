using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;
using System.Data;

namespace Northwind.Web.Pages
{
    public class CustomersModel : PageModel
    {
        private NorthwindContext db;
        public IQueryable<IGrouping<string?, Customer?>?>? Customers { get; set; }

        public CustomersModel(NorthwindContext dbInjected)
        {
            db = dbInjected;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Customers list";
            Customers = db.Customers.GroupBy(c => c.Country);
        }
    }
}
