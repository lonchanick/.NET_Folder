using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Packt.Shared;

namespace Northwind.Web.Pages;

public class CustomerDetailModel : PageModel
{
    public string? Id { get; set; }
    private NorthwindContext db;
    public Customer CustomerOrders { get; set; }

    public CustomerDetailModel(NorthwindContext dbInjected)
    {
        db = dbInjected;
    }

    public void OnGet([FromRoute] string? idcustomer = null)
    {
        Id = idcustomer;
        //var xxxxx = db.Customers.Include(c => c.Orders)
        //    .Where(c => c.CustomerId == idcustomer);

        CustomerOrders = db.Customers.Include(c => c.Orders)
            .FirstOrDefault(c => c.CustomerId == idcustomer);
    }

}
