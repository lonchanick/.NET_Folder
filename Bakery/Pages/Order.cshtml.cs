using Bakery.Data;
using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Bakery.Pages;

public class OrderModel : PageModel
{
    private readonly BakeryContext _bakeryContext;
    public OrderModel(BakeryContext bakeryContext) => _bakeryContext = bakeryContext;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    public Product Product { get; set; }

    [BindProperty, Range(1, int.MaxValue, ErrorMessage ="You must order at least one item")]
    public int Quantity {get; set;}=1;

    [BindProperty, Required, EmailAddress, Display(Name ="Your Email Addresse")]
    public string OrderEmail {get; set;}

    [BindProperty, Required, Display(Name ="Shipping Addresse")]
    public string ShippingAddress {get; set;}

    [BindProperty]
    public decimal UnitPrice {get; set;}

    [TempData]
    public string Confirmation {get; set;}

    public async Task OnGetAsync()
    {
        Product = await _bakeryContext.Products.FindAsync(Id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // aterrizamos en la peticion post hecha desde el navegador y recuperamos el item en cuestion
        // ya que la web es stateless
        // Product = await _bakeryContext.Products.FindAsync(Id);

        if(ModelState.IsValid)
        {
            // iniciamos una nueva basket
            Basket Basket = new();

            // en caso de que la basket ya este almacenando algun item, lo deserializamos y lo agregamos
            // a la basket recien creada
            if(Request.Cookies[nameof(Basket)] is not null)
            {
                Basket = JsonSerializer.Deserialize<Basket>(Request.Cookies[nameof(Basket)]);

            }

            // despues de obtener los items que ya existian en la basket, agregamos el nuevo item a la basket
            Basket.Items.Add(new OrderItem {
                ProductId = Id,
                Quantity = Quantity,
                UnitPrice = UnitPrice
            });

            // seralizamos todo
            var serialized = JsonSerializer.Serialize(Basket);

            // se cambia la duracion de la cookie a 30 dias
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };

            // y guardamos todo en la cookie
            Response.Cookies.Append(nameof(Basket), serialized, cookieOptions);

            return RedirectToPage("Index");
        }
        Product = await _bakeryContext.Products.FindAsync(Id);
        return Page();
    }
 
}
