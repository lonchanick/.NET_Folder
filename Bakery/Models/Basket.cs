namespace Bakery.Models;

public class Basket
{
    public int  BasketId { get; set; }
    public List<OrderItem> Items { get; set; } = new ();
    public int NumberOfItems => Items.Sum(x => x.Quantity); 
}
