using Packt.Shared;

namespace Northwind.Mvc.Models;

public class SupplierAndCategory
{
    public Product? product;
    public IEnumerable<IEnumerable<int>>? SupAndCat;

}
